﻿using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Application.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfigurationService _configurationService;
        private readonly IRolService _rolService;
        private readonly ICardService _cardService;

        public UsersController(IUserService userService, IConfigurationService configurationService, IRolService rolService, ICardService cardService)
        {
            _userService = userService;
            _configurationService = configurationService;
            _rolService = rolService;
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<User>>>> GetUsers()
        {
            var response = await _userService.GetUsersAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<User?>>> GetUser(Guid id)
        {
            var response = await _userService.GetUserAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpPatch]
        public async Task<ResponseMessage<bool>> UpdateConfiguration(UserConfigurationUpdateDto newUserConfigration)
        {
            var response = new ResponseMessage<bool>()
            {
                Success = false,
                Message = "Not found"
            };

            var userData = await _userService.GetUserAsync(newUserConfigration.UserId);
            var configurationData = await _configurationService.GetConfigurationAsync(newUserConfigration.ConfigurationId);

            if (userData.Success && configurationData.Success)
            {
                userData.Data.Configuration = configurationData.Data;
                userData.Data.ConfigurationId = configurationData.Data.Id;

                var userUpdated = await _userService.UpdateUserAsync(userData.Data);
                response.Success = userUpdated.Success;
                response.Message = userUpdated.Message;
                response.Data = userUpdated.Data;
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<User>>> CreateUser(UserCreateDto user)
        {
            var userData = await _userService.GetUserByUsernameAsync(user.Username);
            if (userData != null)
            {
                return BadRequest("Este nombre de usuario ya está en uso");
            }


            var userCreated = new User
            {
                Id = Guid.NewGuid(),
                Username = user.Username,
                Password = EncryptionHelper.EncryptString("123456"),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                IsMale = user.IsMale,
            };

            var roleData = await _rolService.GetRoleAsync(user.RoleId);
            if(roleData.Success)
            {
                userCreated.Role = roleData.Data;
                userCreated.RoleId = roleData.Data.Id;
            }

            var configurationData = await _configurationService.GetConfigurationsAsync();
            if(configurationData.Success)
            {
                var configuration = configurationData.Data.Where(c => c.Name == "Default").FirstOrDefault();
                userCreated.Configuration = configuration;
                userCreated.ConfigurationId = configuration.Id;
            }

            if (user.LeadId != null)
            {
                var leadData = await _userService.GetUserAsync((Guid)user.LeadId);
                if (leadData.Success)
                {
                    userCreated.LeadId = leadData.Data.Id;
                    userCreated.Lead = leadData.Data;
                }
            }

            var response = await _userService.CreateUserAsync(userCreated);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateUser(UserCreateDto user)
        {
            var currentUserData = await _userService.GetUserAsync((Guid)user.Id);

            if (currentUserData.Success) 
            { 
                var roleData = await _rolService.GetRoleAsync(user.RoleId);
                if (roleData.Success && roleData.Data.Id != currentUserData.Data.RoleId)
                {
                    currentUserData.Data.RoleId = roleData.Data.Id;
                    currentUserData.Data.Role = roleData.Data;
                }

                if (user.LeadId != null)
                {
                    var leadData = await _userService.GetUserAsync((Guid)user.LeadId);
                    if (leadData.Success && leadData.Data.Id != currentUserData.Data.LeadId)
                    {
                        currentUserData.Data.LeadId = leadData.Data.Id;
                        currentUserData.Data.Lead = leadData.Data;
                    }
                }

                currentUserData.Data.Username = user.Username;
                currentUserData.Data.FirstName = user.FirstName;
                currentUserData.Data.LastName = user.LastName;
                currentUserData.Data.Email = user.Email;
                currentUserData.Data.IsMale = user.IsMale;
            }

            var response = await _userService.UpdateUserAsync(currentUserData.Data);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteUser(Guid userId)
        {
            var cards = await _cardService.GetCardsAsync(userId);
            var response = new ResponseMessage<bool>()
            {
                Success = cards.Success,
                Message = cards.Message,
                Data = cards.Success
            };

            if (cards.Success)
            {
                foreach (var card in cards.Data)
                {
                    await _cardService.DeleteCardAsync(card.Id);
                }
                
                response = await _userService.DeleteUserAsync(userId);

                if (response.Success)
                {
                    return Ok(response);
                }
            }
            return BadRequest(response);
        }
    }
}

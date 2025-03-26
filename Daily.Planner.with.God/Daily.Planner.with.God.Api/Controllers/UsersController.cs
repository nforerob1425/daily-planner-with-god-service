using Microsoft.AspNetCore.Mvc;
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

        public UsersController(IUserService userService, IConfigurationService configurationService)
        {
            _userService = userService;
            _configurationService = configurationService;
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
            var userCreated = new User
            {
                Username = user.Username,
                RoleId = user.RoleId,
                Password = EncryptionHelper.EncryptString(user.Password),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ConfigurationId = user.ConfigurationId,
                LeadId = user.LeadId
            };

            var response = await _userService.CreateUserAsync(userCreated);
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetUser), new { id = response.Data.Id }, response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateUser(UserCreateDto user)
        {
            var userUpdated = new User
            {
                Username = user.Username,
                RoleId = user.RoleId,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ConfigurationId = user.ConfigurationId,
                LeadId = user.LeadId
            };

            var response = await _userService.UpdateUserAsync(userUpdated);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteUser(Guid id)
        {
            var response = await _userService.DeleteUserAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

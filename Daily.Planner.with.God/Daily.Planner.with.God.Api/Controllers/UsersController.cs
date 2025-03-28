﻿using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Application.Dtos;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
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

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<User>>> CreateUser(UserDto user)
        {
            var userCreated = new User
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

            var response = await _userService.CreateUserAsync(userCreated);
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetUser), new { id = response.Data.Id }, response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateUser(UserDto user)
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

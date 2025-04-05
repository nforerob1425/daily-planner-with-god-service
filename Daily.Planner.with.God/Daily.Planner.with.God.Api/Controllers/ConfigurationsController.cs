using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;
using Microsoft.AspNetCore.Authorization;
using Daily.Planner.with.God.Application.Services;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;
        private readonly IUserService _userService;

        public ConfigurationsController(IConfigurationService configurationService, IUserService userService)
        {
            _configurationService = configurationService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Configuration>>>> GetConfigurations()
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CSCN"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var response = await _configurationService.GetConfigurationsAsync();
                if (response.Success)
                {
                    return Ok(response);
                }
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

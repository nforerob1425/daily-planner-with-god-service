using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfigurationService _configurationService;

        public ConfigurationsController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Configuration>>>> GetConfigurations()
        {
            var response = await _configurationService.GetConfigurationsAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<Configuration?>>> GetConfiguration(Guid id)
        {
            var response = await _configurationService.GetConfigurationAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Configuration>>> CreateConfiguration(Configuration configuration)
        {
            var response = await _configurationService.CreateConfigurationAsync(configuration);
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetConfiguration), new { id = response.Data.Id }, response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateConfiguration(Configuration configuration)
        {
            var response = await _configurationService.UpdateConfigurationAsync(configuration);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteConfiguration(Guid id)
        {
            var response = await _configurationService.DeleteConfigurationAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

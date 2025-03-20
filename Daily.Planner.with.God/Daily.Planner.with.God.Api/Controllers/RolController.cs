using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;

namespace Daily.Planner.with.God.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Role>>>> GetRoles()
        {
            var result = await _rolService.GetRolesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<Role?>>> GetRole(Guid id)
        {
            var result = await _rolService.GetRoleAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Role>>> CreateRole(Role role)
        {
            var result = await _rolService.CreateRoleAsync(role);
            return CreatedAtAction(nameof(GetRole), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateRole(Guid id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            var result = await _rolService.UpdateRoleAsync(role);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteRole(Guid id)
        {
            var result = await _rolService.DeleteRoleAsync(id);
            return Ok(result);
        }
    }
}

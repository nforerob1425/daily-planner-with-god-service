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
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Permission>>>> GetPermissions()
        {
            var result = await _permissionService.GetPermissionsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<Permission?>>> GetPermission(Guid id)
        {
            var result = await _permissionService.GetPermissionAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Permission>>> CreatePermission(Permission permission)
        {
            var result = await _permissionService.CreatePermissionAsync(permission);
            return CreatedAtAction(nameof(GetPermission), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdatePermission(Guid id, Permission permission)
        {
            if (id != permission.Id)
            {
                return BadRequest();
            }

            var result = await _permissionService.UpdatePermissionAsync(permission);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeletePermission(Guid id)
        {
            var result = await _permissionService.DeletePermissionAsync(id);
            return Ok(result);
        }
    }
}

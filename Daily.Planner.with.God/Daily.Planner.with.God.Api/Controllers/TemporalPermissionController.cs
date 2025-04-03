using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TemporalPermissionController : Controller
    {
        private readonly ITemporalPermissionService _temporalPermissionService;
        private readonly IUserService _userService;
        private readonly IRolService _rolService;
        private readonly IPermissionService _permissionService;

        public TemporalPermissionController(ITemporalPermissionService temporalPermissionService, IUserService userService, IRolService rolService, IPermissionService permissionService)
        {
            _temporalPermissionService = temporalPermissionService;
            _userService = userService;
            _rolService = rolService;
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<TemporalPermission>>>> GetAll()
        {
            try
            {
                Request.Headers.TryGetValue("UserId", out var currentUserId);
                Guid userId = Guid.Parse(currentUserId.ToString());

                var notesData = await _temporalPermissionService.GetAllAsync();
                return Ok(notesData);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

        }

        [HttpPost]
        public async Task<ResponseMessage<TemporalPermission>> CreateNote(TemporalPermissionCreateDto tpToCreate)
        {
            var tp = new TemporalPermission();
            var roleData = await _rolService.GetRoleAsync(tpToCreate.RoleId);
            var permissionData = await _permissionService.GetPermissionAsync(tpToCreate.PermissionId);

            if (permissionData.Success && roleData.Success)
            {
                tp.RoleId = tpToCreate.RoleId;
                tp.PermissionId = tpToCreate.PermissionId;
                tp.Permission = permissionData.Data;
                tp.Role = roleData.Data;
            }

            var createdData = await _temporalPermissionService.CreateAsync(tp);
            return createdData;
        }

        [HttpDelete("{tpId}")]
        public async Task<ResponseMessage<bool>> DeleteNote(Guid tpId)
        {
            var deletedData = await _temporalPermissionService.DeleteAsync(tpId);
            return deletedData;
        }
    }
}

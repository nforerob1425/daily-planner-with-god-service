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
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CSTP"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                try
                {
                    Guid userId = Guid.Parse(currentUserId.ToString());

                    var notesData = await _temporalPermissionService.GetAllAsync();
                    return Ok(notesData);

                }
                catch (Exception)
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<TemporalPermission>>> CreateNote(TemporalPermissionCreateDto tpToCreate)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CCTP"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

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
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete("{tpId}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteNote(Guid tpId)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CDTP"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var deletedData = await _temporalPermissionService.DeleteAsync(tpId);
                return deletedData;
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

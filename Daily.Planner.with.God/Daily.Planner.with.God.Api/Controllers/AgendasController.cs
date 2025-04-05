using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Common;
using Microsoft.AspNetCore.Authorization;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgendasController : ControllerBase
    {
        private readonly IAgendaService _agendaService;
        private readonly IUserService _userService;

        public AgendasController(IAgendaService agendaService, IUserService userService)
        {
            _agendaService = agendaService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Agenda>>>> GetAgendasByGender(bool isMale)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CSAG"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var response = await _agendaService.GetAgendasAsync(isMale);
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

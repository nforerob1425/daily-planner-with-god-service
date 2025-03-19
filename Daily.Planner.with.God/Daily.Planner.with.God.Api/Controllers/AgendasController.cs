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
    public class AgendasController : ControllerBase
    {
        private readonly IAgendaService _agendaService;

        public AgendasController(IAgendaService agendaService)
        {
            _agendaService = agendaService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Agenda>>>> GetAgendas()
        {
            var response = await _agendaService.GetAgendasAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<Agenda?>>> GetAgenda(Guid id)
        {
            var response = await _agendaService.GetAgendaAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Agenda>>> CreateAgenda(Agenda agenda)
        {
            var response = await _agendaService.CreateAgendaAsync(agenda);
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetAgenda), new { id = response.Data.Id }, response);
            }
            return BadRequest(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateAgenda(Agenda agenda)
        {
            var response = await _agendaService.UpdateAgendaAsync(agenda);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteAgenda(Guid id)
        {
            var response = await _agendaService.DeleteAgendaAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}

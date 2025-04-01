using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize]
    public class AppAdministrationController : Controller
    {
        private readonly IAgendaService _agendaService;
        private readonly IColorPalettService _colorPalettService;
        private readonly ITypeService _typeService;

        public AppAdministrationController(IAgendaService agendaService, IColorPalettService colorPalettService, ITypeService typeService)
        {
            _agendaService = agendaService;
            _colorPalettService = colorPalettService;
            _typeService = typeService;
        }

        [HttpGet]
        [Route("agendas")]
        public async Task<ResponseMessage<List<Agenda>>> GetAllAgendas()
        {
            var agendas = await _agendaService.GetAgendasAsync();
            return agendas;
        }

        [HttpGet]
        [Route("colors")]
        public async Task<ResponseMessage<List<ColorPalett>>> GetAllColors()
        {
            var colorPaletts = await _colorPalettService.GetColorPalettsAsync();
            return colorPaletts;
        }

        [HttpGet]
        [Route("types")]
        public async Task<ResponseMessage<List<Domain.Entities.Type>>> GetAllColorTypes()
        {
            var colorTypes = await _typeService.GetTypesAsync();
            return colorTypes;
        }

        [HttpPut]
        [Route("agendas")]
        public async Task<ResponseMessage<Agenda>> CreateNewAgenda(AgendaCreateDto agendaToCreate)
        {
            
            var agenda = new Agenda()
            {
                Year = agendaToCreate.Year,
                Title = agendaToCreate.Title,
                Content = agendaToCreate.Content,
                ImageBackgroundSrc = agendaToCreate.ImageBackgroundSrc,
                IsReported = agendaToCreate.IsReported,
                IsMale = agendaToCreate.IsMale,
            };

            if (agendaToCreate.OriginalAgendaId != null)
            {
                var originalAgenda = await _agendaService.GetAgendaAsync((Guid)agendaToCreate.OriginalAgendaId);
                if (originalAgenda.Success)
                {
                    agenda.OriginalAgenda = originalAgenda.Data;
                    agenda.OriginalAgendaId = agendaToCreate?.OriginalAgendaId;
                }
            }
            var agendaCreated = await _agendaService.CreateAgendaAsync(agenda);
            return agendaCreated;
        }

        [HttpPut]
        [Route("colors")]
        public async Task<ResponseMessage<ColorPalett>> CreateNewColor(ColorCreateDto colorPaletteToCreate)
        {
            var colorPalette = new ColorPalett()
            {
                Color = colorPaletteToCreate.Color,
                TypeId = colorPaletteToCreate.TypeId
            };

            var colorCreated = await _colorPalettService.CreateColorPalettAsync(colorPalette);
            return colorCreated;
        }

        [HttpPost]
        [Route("agendas")]
        public async Task<ResponseMessage<bool>> UpdateAgenda(AgendaUpdateDto agendaToUpdate)
        {
            var agenda = new Agenda()
            {
                Id = agendaToUpdate.Id,
                Year = agendaToUpdate.Year,
                Title = agendaToUpdate.Title,
                Content = agendaToUpdate.Content,
                ImageBackgroundSrc = agendaToUpdate.ImageBackgroundSrc,
                IsReported = agendaToUpdate.IsReported,
                IsMale = agendaToUpdate.IsMale,
            };

            if (agendaToUpdate.OriginalAgendaId != null)
            {
                var originalAgenda = await _agendaService.GetAgendaAsync((Guid)agendaToUpdate.OriginalAgendaId);
                if (originalAgenda.Success)
                {
                    agenda.OriginalAgenda = originalAgenda.Data;
                    agenda.OriginalAgendaId = agendaToUpdate?.OriginalAgendaId;
                }
            }
            var updated = await _agendaService.UpdateAgendaAsync(agenda);
            return updated;
        }

        [HttpPost]
        [Route("colors")]
        public async Task<ResponseMessage<bool>> UpdateColor(ColorUpdateDto colorPaletteToUpdate)
        {
            var colorPalette = new ColorPalett()
            {
                Id = colorPaletteToUpdate.Id,
                Color = colorPaletteToUpdate.Color,
                TypeId = colorPaletteToUpdate.TypeId
            };

            var updated = await _colorPalettService.UpdateColorPalettAsync(colorPalette);
            return updated;
        }

        [HttpDelete]
        [Route("agendas")]
        public async Task<ResponseMessage<bool>> DeleteAgenda([FromQuery] Guid agendaId)
        {
            var deleted = await _agendaService.DeleteAgendaAsync(agendaId);
            return deleted;
        }

        [HttpDelete]
        [Route("colors")]
        public async Task<ResponseMessage<bool>> DeleteColor([FromQuery] Guid colorPaletteId)
        {
            var deleted = await _colorPalettService.DeleteColorPalettAsync(colorPaletteId);
            return deleted;
        }
    }
}

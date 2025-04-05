using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Application.Services;
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
        private readonly IApplicationConfigServices _applicationConfigServices;
        private readonly IUserService _userService; 

        public AppAdministrationController(IAgendaService agendaService, IColorPalettService colorPalettService, ITypeService typeService, IApplicationConfigServices applicationConfigServices, IUserService userService)
        {
            _agendaService = agendaService;
            _colorPalettService = colorPalettService;
            _typeService = typeService;
            _applicationConfigServices = applicationConfigServices;
            _userService = userService;
        }

        [HttpGet]
        [Route("appConfigs")]
        public async Task<ActionResult<ResponseMessage<List<ApplicationConfig>>>> GetAllAppConfigs()
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CSAP"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var appConfigs = await _applicationConfigServices.GetApplicationConfigsAsync();
                return Ok(appConfigs);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("agendas")]
        public async Task<ActionResult<ResponseMessage<List<Agenda>>>> GetAllAgendas()
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CSAG"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var agendas = await _agendaService.GetAgendasAsync();
                return Ok(agendas);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("colors")]
        public async Task<ActionResult<ResponseMessage<List<ColorPalett>>>> GetAllColors()
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CSCO"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var colorPaletts = await _colorPalettService.GetColorPalettsAsync();
                return Ok(colorPaletts);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpGet]
        [Route("types")]
        public async Task<ActionResult<ResponseMessage<List<Domain.Entities.Type>>>> GetAllColorTypes()
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CSTC"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var colorTypes = await _typeService.GetTypesAsync();
                colorTypes.Data = colorTypes.Data.OrderBy(c => c.Name).ToList();
                return Ok(colorTypes);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut]
        [Route("agendas")]
        public async Task<ActionResult<ResponseMessage<Agenda>>> CreateNewAgenda(AgendaCreateDto agendaToCreate)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CCAG", "CSAG"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

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
                return Ok(agendaCreated);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPut]
        [Route("colors")]
        public async Task<ActionResult<ResponseMessage<ColorPalett>>> CreateNewColor(ColorCreateDto colorPaletteToCreate)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CCCO"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var colorPalette = new ColorPalett()
                {
                    Color = colorPaletteToCreate.Color,
                    TypeId = colorPaletteToCreate.TypeId
                };

                var colorCreated = await _colorPalettService.CreateColorPalettAsync(colorPalette);
                return Ok(colorCreated);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("agendas")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateAgenda(AgendaUpdateDto agendaToUpdate)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CUAG", "CSAG"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

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
                return Ok(updated);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("colors")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateColor(ColorUpdateDto colorPaletteToUpdate)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CUCO"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var colorPalette = new ColorPalett()
                {
                    Id = colorPaletteToUpdate.Id,
                    Color = colorPaletteToUpdate.Color,
                    TypeId = colorPaletteToUpdate.TypeId
                };

                var updated = await _colorPalettService.UpdateColorPalettAsync(colorPalette);
                return Ok(updated);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("appConfigs")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateAppConfigs(ApplicationConfig appConfig)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CUAP"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var updated = await _applicationConfigServices.UpdateApplicationConfigAsync(appConfig);
                return Ok(updated);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        [Route("agendas")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteAgenda([FromQuery] Guid agendaId)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CDAG"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var deleted = await _agendaService.DeleteAgendaAsync(agendaId);
                return Ok(deleted);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        [Route("colors")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteColor([FromQuery] Guid colorPaletteId)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userId = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userId, ["CDCO"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var deleted = await _colorPalettService.DeleteColorPalettAsync(colorPaletteId);
                return Ok(deleted);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

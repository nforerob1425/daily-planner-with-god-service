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
    public class PetitionTypesController : Controller
    {
        private readonly IPetitionTypesService _petitionTypesService;

        public PetitionTypesController(IPetitionTypesService petitionTypesService)
        {
            _petitionTypesService = petitionTypesService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<PetitionType>>>> GetTypes()
        {
            var result = await _petitionTypesService.GetPetitionTypesAsync();
            return Ok(result);
        }
    }
}

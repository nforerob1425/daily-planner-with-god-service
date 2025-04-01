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

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<PetitionType?>>> GetType(Guid id)
        {
            var result = await _petitionTypesService.GetPetitionTypeAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<PetitionType>>> CreateType(PetitionType type)
        {
            var result = await _petitionTypesService.CreatePetitionTypeAsync(type);
            return CreatedAtAction(nameof(GetType), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateType(Guid id, PetitionType type)
        {
            if (id != type.Id)
            {
                return BadRequest();
            }

            var result = await _petitionTypesService.UpdatePetitionTypeAsync(type);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteType(Guid id)
        {
            var result = await _petitionTypesService.DeletePetitionTypeAsync(id);
            return Ok(result);
        }
    }
}

using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Application.Services;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetitionsController : Controller
    {
        private readonly IPetitionService _petitionService;
        private readonly IPetitionTypesService _petitionTypesService;
        private readonly IUserService _userService;

        public PetitionsController(IPetitionService petitionService, IPetitionTypesService petitionTypesService, IUserService userService)
        {
            _petitionService = petitionService;
            _petitionTypesService = petitionTypesService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Petition>>>> GetPetitions([FromQuery] Guid userId)
        {
            var result = await _petitionService.GetPetitionsAsync(userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<Petition?>>> GetType(Guid id)
        {
            var result = await _petitionService.GetPetitionAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Petition>>> CreateType(PetitionCreateDto petition)
        {
            var petitionToCreate = new Petition()
            {
                Id = Guid.NewGuid(),
                Content = petition.Content,
                CreatedDate = petition.CreatedDate,
                IsPraying = false,
                PetitionTypeId = petition.PetitionTypeId,
                PrayFor = petition.PrayFor,
                UserId = petition.UserId,
            };

            var currentUser = await _userService.GetUserAsync(petition.UserId);
            var reportToUser = await _userService.GetUserAsync((Guid)currentUser.Data.LeadId);
            var petitionType = await _petitionTypesService.GetPetitionTypeAsync(petition.PetitionTypeId);

            if (currentUser.Success && reportToUser.Success && petitionType.Success)
            {
                petitionToCreate.User = currentUser.Data;
                petitionToCreate.ReportedToUser = reportToUser.Data;
                petitionToCreate.ReportedToUserId = reportToUser.Data.Id;
                petitionToCreate.PetitionType = petitionType.Data;
            }

            var result = await _petitionService.CreatePetitionAsync(petitionToCreate);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateType(Guid id, Petition petition)
        {
            if (id != petition.Id)
            {
                return BadRequest();
            }

            var result = await _petitionService.UpdatePetitionAsync(petition);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteType(Guid id)
        {
            var result = await _petitionService.DeletePetitionAsync(id);
            return Ok(result);
        }
    }
}

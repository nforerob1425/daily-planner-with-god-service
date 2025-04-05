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
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CSPT"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var result = await _petitionService.GetPetitionsAsync(userId);
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Petition>>> CreatePetition(PetitionCreateDto petition)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CCPT", "CSUS"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

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
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMessage<bool>>> DeletePetition(Guid id)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CDPT"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var result = await _petitionService.DeletePetitionAsync(id);
                return Ok(result);
            }
            else 
            { 
                return Unauthorized();
            }
        }

        [HttpPatch]
        public async Task<ActionResult<ResponseMessage<bool>>> SetPrayPetition([FromQuery] Guid petitionId)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CUPT", "CSPT"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var response = new ResponseMessage<bool>()
                {
                    Data = false,
                    Message = "Petition not found",
                    Success = false
                };

                var petitionData = await _petitionService.GetPetitionAsync(petitionId);
                if (petitionData.Success)
                {
                    response.Message = petitionData.Message;
                    petitionData.Data.IsPraying = !petitionData.Data.IsPraying;
                    var petitionUpdatedData = await _petitionService.UpdatePetitionAsync(petitionData.Data);
                    if (petitionUpdatedData.Success)
                    {
                        response.Success = petitionUpdatedData.Success;
                        response.Data = petitionUpdatedData.Data;
                        response.Message = petitionUpdatedData.Message;
                    }
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

using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlannerController : Controller
    {
        private readonly ICardService _cardService;
        private readonly IUserService _userService;
        private readonly IAgendaService _agendaService;
        public PlannerController(ICardService cardService, IUserService userService, IAgendaService agendaService)
        {
            this._cardService = cardService;
            _userService = userService;
            _agendaService = agendaService;
        }

        [HttpPatch]
        public async Task<ActionResult<ResponseMessage<bool>>> ReportPlanner([FromQuery] Guid userId)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CRCD", "CSCD", "CSUS", "CSAG", "CUCD", "CCCD"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var response = new ResponseMessage<bool>();

                var allCards = await _cardService.GetNonReportedCards(userId);
                var currentUser = await _userService.GetUserAsync(userId);
                ResponseMessage<List<Domain.Entities.Agenda>> allAgendas = null;

                if (currentUser != null && currentUser.Success)
                {
                    allAgendas = await _agendaService.GetAgendasAsync(currentUser.Data.IsMale);
                }

                if (allCards.Success && currentUser.Success && allAgendas != null)
                {
                    foreach (var card in allCards.Data)
                    {
                        var agendaToBeReported = allAgendas.Data.Where(a => a.OriginalAgendaId == card.AgendaId).FirstOrDefault();
                        card.Reported = true;
                        await _cardService.UpdateCardAsync(card);

                        var cardTocreate = card;

                        cardTocreate.UserId = (Guid)currentUser.Data.LeadId;
                        cardTocreate.User = currentUser.Data.Lead;
                        cardTocreate.Agenda = agendaToBeReported;
                        cardTocreate.AgendaId = agendaToBeReported.Id;

                        await _cardService.CreateCardAsync(cardTocreate);
                    }
                }

                response.Message = allCards.Message;
                response.Success = allCards.Success;
                response.Data = allCards.Success;

                return response;
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

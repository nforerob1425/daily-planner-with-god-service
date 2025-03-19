using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Card>>>> GetCards()
        {
            return await _cardService.GetCardsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseMessage<Card>>> GetCard(Guid id)
        {
            var card = await _cardService.GetCardAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return card;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Card>>> CreateCard(Card card)
        {
            return await _cardService.CreateCardAsync(card);
        }

        [HttpPut("{id}")]
        public async Task<ResponseMessage<bool>> UpdateCard(Guid id, Card card)
        {
            return await _cardService.UpdateCardAsync(id, card);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseMessage<bool>> DeleteCard(Guid id)
        {
            return await _cardService.DeleteCardAsync(id);
        }
    }
}

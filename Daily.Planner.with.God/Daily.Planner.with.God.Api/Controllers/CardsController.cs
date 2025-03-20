using AutoMapper;
using Daily.Planner.with.God.Application.Dtos;
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
        private readonly IMapper _mapper;

        public CardsController(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
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
        public async Task<ActionResult<ResponseMessage<Card>>> CreateCard(CardCreateDto cardtoCreate)
        {
            var card = new Card
            {
                CreateDate = cardtoCreate.CreateDate,
                Title = cardtoCreate.Title,
                Content = cardtoCreate.Content,
                Favorite = cardtoCreate.Favorite,
                PrimaryColorId = cardtoCreate.PrimaryColorId,
                LetterColorId = cardtoCreate.LetterColorId,
                TitleColorId = cardtoCreate.TitleColorId,
                LetterDateColorId = cardtoCreate.LetterDateColorId,
                PrimaryColorDateId = cardtoCreate.PrimaryColorDateId,
                Versicle = cardtoCreate.Versicle,
                UserId = cardtoCreate.UserId,
                AgendaId = cardtoCreate.AgendaId,
                OriginalUserId = cardtoCreate.UserId
            };

            return await _cardService.CreateCardAsync(card);
        }

        [HttpPut("{id}")]
        public async Task<ResponseMessage<bool>> UpdateCard(CardUpdateDto cardToUpdate)
        {
            var cardResponse = await _cardService.GetCardAsync(cardToUpdate.Id);
            if (cardResponse.Success)
            {
                var card = cardResponse.Data;
                _mapper.Map(cardToUpdate, card);
                return await _cardService.UpdateCardAsync(card);
            }
            else
            {
                return new ResponseMessage<bool>
                {
                    Success = false,
                    Message = "Card not found"
                };
            }
        }

        [HttpDelete("{id}")]
        public async Task<ResponseMessage<bool>> DeleteCard(Guid id)
        {
            return await _cardService.DeleteCardAsync(id);
        }
    }
}

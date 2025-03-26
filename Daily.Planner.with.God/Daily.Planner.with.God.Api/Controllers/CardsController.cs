using AutoMapper;
using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly IColorPalettService _colorPalettService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CardsController(ICardService cardService, IMapper mapper, IColorPalettService colorPalettService, IUserService userService)
        {
            _cardService = cardService;
            _mapper = mapper;
            _colorPalettService = colorPalettService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<CardInfoDto>>>> GetCards([FromQuery] Guid userId)
        {
            var cards = await _cardService.GetCardsAsync(userId);            
            List<CardInfoDto> cardsDto = new List<CardInfoDto>();

            foreach (var card in cards.Data)
            {
                var cardDto = await GetCustomCardInfoAsync(card);
                cardsDto.Add(cardDto);
            }   

            var response = new ResponseMessage<List<CardInfoDto>>
            {
                Data = cardsDto,
                Message = cards.Message,
                Success = cards.Success
            };

            return response;
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

        [HttpPatch]
        public async Task<ActionResult<ResponseMessage<bool>>> SetFavoriteCard([FromQuery] Guid cardId)
        {
            var response = new ResponseMessage<bool>()
            {
                Data = false,
                Message = "Card not found",
                Success = false
            };

            var cardData = await _cardService.GetCardAsync(cardId);
            if (cardData.Success)
            {
                response.Message = cardData.Message;
                cardData.Data.Favorite = !cardData.Data.Favorite;
                var cardUpdatedData = await _cardService.SetFavoriteCard(cardData.Data);
                if (cardUpdatedData.Success)
                {
                    response.Success = cardUpdatedData.Success;
                    response.Data = cardUpdatedData.Data;
                    response.Message = cardUpdatedData.Message;
                }
            }
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<CardInfoDto>>> CreateCard(CardCreateDto cardtoCreate)
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

            var createdCard = await _cardService.CreateCardAsync(card);

            var cardDto = new CardInfoDto();

            if (createdCard.Success && createdCard.Data != null)
            {
                cardDto = await GetCustomCardInfoAsync(card);
            }

            return new ActionResult<ResponseMessage<CardInfoDto>>(new ResponseMessage<CardInfoDto>
            {
                Data = cardDto,
                Message = createdCard.Message,
                Success = createdCard.Success
            });
        }

        [HttpPut]
        public async Task<ResponseMessage<bool>> UpdateCard(CardUpdateDto cardToUpdate)
        {
            var cardResponse = await _cardService.GetCardAsync(cardToUpdate.Id);
            if (cardResponse.Success)
            {
                var card = cardResponse.Data;
                var userData = await _userService.GetUserAsync(card.UserId);
                _mapper.Map(cardToUpdate, card);
                card.OriginalUser = userData.Success ? userData.Data : null;
                card.OriginalUserId = userData.Success ? userData.Data.Id : Guid.Empty;
                var cardUpdated = await _cardService.UpdateCardAsync(card);
                if (cardUpdated.Success)
                {
                    return cardUpdated;
                }
            }
            return new ResponseMessage<bool>
            {
                Success = false,
                Message = "Card not found"
            };
        }

        [HttpDelete("{id}")]
        public async Task<ResponseMessage<bool>> DeleteCard(Guid id)
        {
            return await _cardService.DeleteCardAsync(id);
        }

        private async Task<CardInfoDto> GetCustomCardInfoAsync(Card card)
        {
            var primaryColor = await _colorPalettService.GetColorPalettAsync(card.PrimaryColorId);
            var letterColor = await _colorPalettService.GetColorPalettAsync(card.LetterColorId);
            var titleColor = await _colorPalettService.GetColorPalettAsync(card.TitleColorId);
            var letterDateColor = await _colorPalettService.GetColorPalettAsync(card.LetterDateColorId);
            var primaryColorDate = await _colorPalettService.GetColorPalettAsync(card.PrimaryColorDateId);
            var user = await _userService.GetUserAsync(card.OriginalUserId);

            var cardDto = new CardInfoDto()
            {
                Id = card.Id,
                CreateDate = card.CreateDate,
                MonthCreated = card.CreateDate.ToString("MMMM"),
                DayCreated = card.CreateDate.ToString("dd"),
                Title = card.Title,
                Content = card.Content,
                Favorite = card.Favorite,
                PrimaryColor = primaryColor.Data.Color,
                LetterColor = letterColor.Data.Color,
                TitleColor = titleColor.Data.Color,
                Versicle = card.Versicle,
                PrimaryColorDate = primaryColorDate.Data.Color,
                LetterDateColor = letterDateColor.Data.Color,
                UserId = card.UserId,
                AgendaId = card.AgendaId,
                OriginalUserFullName = string.Concat(user.Data.FirstName, " ", user.Data.LastName),
                Reported = card.Reported
            };

            return cardDto;
        }
    }
}

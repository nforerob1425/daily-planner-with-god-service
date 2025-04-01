using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IColorPalettService _colorPalettService;
        private readonly IUserService _userService;

        public CardService(ICardRepository cardRepository, IColorPalettService colorPalettService, IUserService userService)
        {
            _cardRepository = cardRepository;
            _colorPalettService = colorPalettService;
            _userService = userService;
        }

        public async Task<ResponseMessage<List<Card>>> GetCardsAsync()
        {
            try
            {
                return await _cardRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<ResponseMessage<List<Card>>> GetCardsAsync(Guid userId)
        {
            try
            {
                return await _cardRepository.GetAllCardsByUserId(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ResponseMessage<Card?>> GetCardAsync(Guid id)
        {
            try
            {
                return await _cardRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseMessage<Card>> CreateCardAsync(Card card)
        {
            try
            {
                card.Id = Guid.NewGuid();
                return await _cardRepository.CreateAsync(card);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseMessage<bool>> UpdateCardAsync(Card card)
        {
            try
            {
                return await _cardRepository.UpdateAsync(card);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteCardAsync(Guid id)
        {
            try
            {
                return await _cardRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseMessage<bool>> SetFavoriteCard(Card card)
        {
            try
            {
                return await _cardRepository.UpdateAsync(card);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<CardInfoDto> GetCustomCardInfoAsync(Card card)
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
                Created = card.CreateDate,
                CreateDate = card.CreateDate.ToString("yyyy"),
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

        public Task<ResponseMessage<List<Card>>> GetNonReportedCards(Guid userId)
        {
            var nonReportedCards = _cardRepository.GetAllCardsNoReportedByUserId(userId);
            return nonReportedCards;
        }
    }
}

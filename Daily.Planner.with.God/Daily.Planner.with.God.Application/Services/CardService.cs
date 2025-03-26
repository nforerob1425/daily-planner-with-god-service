using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
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
    }
}

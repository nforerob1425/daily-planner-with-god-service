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
                return await _cardRepository.GetCardsAsync();
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
                return await _cardRepository.GetCardAsync(id);
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
                return await _cardRepository.CreateCardAsync(card);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseMessage<bool>> UpdateCardAsync(Guid id, Card card)
        {
            try
            {
                return await _cardRepository.UpdateCardAsync(id, card);
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
                return await _cardRepository.DeleteCardAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

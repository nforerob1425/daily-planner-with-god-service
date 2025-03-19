using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task<ResponseMessage<List<Card>>> GetCardsAsync()
        {
            var response = new ResponseMessage<List<Card>>();
            try
            {
                var cards = await _context.Cards.ToListAsync();

                response = new ResponseMessage<List<Card>>
                {
                    Data = cards,
                    Message = "Cards found",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting Cards, Error: {ex.Message}";
                response.Success = false;
            }

            return response;
        }
        public async Task<ResponseMessage<Card?>> GetCardAsync(Guid id)
        {
            var response = new ResponseMessage<Card?>();
            try
            {
                var card = await _context.Cards.FindAsync(id);
                response = new ResponseMessage<Card?>
                {
                    Data = card,
                    Message = card == null ? $"Card not found with id: {id}" : "Card found",
                    Success = card != null
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting Card: {id}, Error: {ex.Message}";
                response.Success = false;
            }
            
            return response;
        }
        public async Task<ResponseMessage<Card>> CreateCardAsync(Card card)
        {
            card.Id = Guid.NewGuid();
            var response = new ResponseMessage<Card>
            {
                Data = card
            };

            try
            {
                _context.Cards.Add(card);
                await _context.SaveChangesAsync();
                response.Message = "Card created";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = $"Error created Card, Error: {ex.Message}";
                response.Success = false;
            }
            return response;
        }
        public async Task<ResponseMessage<bool>> UpdateCardAsync(Guid id, Card card)
        {
            var response = new ResponseMessage<bool>();
            try
            {

                if (id != card.Id)
                {
                    response.Data = false;
                    response.Success = true;
                    response.Message = "Id not match";
                }
                else
                {
                    _context.Entry(card).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    response.Data = true;
                    response.Success = true;
                    response.Message = "Card updated";
                } 
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error updating Card: {id}, Error: {ex.Message}";
            }
            
            return response;
        }
        public async Task<ResponseMessage<bool>> DeleteCardAsync(Guid id)
        {
            var response = new ResponseMessage<bool>();
            try
            {
                var card = await _context.Cards.FindAsync(id);
                if (card == null)
                {
                    response.Data = false;
                    response.Success = true;
                    response.Message = "Card not found";
                }
                else
                {
                    _context.Cards.Remove(card);
                    await _context.SaveChangesAsync();
                    response.Data = true;
                    response.Success = true;
                    response.Message = "Card deleted";
                }
                    
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error deleting Card: {id}, Error: {ex.Message}";
            }
            
            return response;
        }
    }
}

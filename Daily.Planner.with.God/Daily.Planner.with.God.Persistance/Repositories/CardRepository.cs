using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private readonly ApplicationDbContext _context;
        public CardRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<ResponseMessage<List<Card>>> GetAllCardsByUserId(Guid userId)
        {
            var response = new ResponseMessage<List<Card>>();
            try
            {
                var cards = _context.Cards.Where(c => c.UserId == userId).ToList();
                response = new ResponseMessage<List<Card>>
                {
                    Data = cards,
                    Message = $"Cards found for user: {userId}",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting cards for user: {userId}, Error: {ex.Message}";
                response.Success = false;
            }
            return response;
        }
    }
}

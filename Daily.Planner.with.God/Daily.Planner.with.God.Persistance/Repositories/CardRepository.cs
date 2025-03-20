using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(ApplicationDbContext context) : base(context) { }
    }
}

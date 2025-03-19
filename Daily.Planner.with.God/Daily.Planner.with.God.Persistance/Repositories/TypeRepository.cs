using Daily.Planner.with.God.Persistance.Interfaces;
using Type = Daily.Planner.with.God.Domain.Entities.Type;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class TypeRepository : Repository<Type>, ITypeRepository
    {
        public TypeRepository(ApplicationDbContext context) : base(context) { }
    }
}

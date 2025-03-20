using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class RolRepository : Repository<Role>, IRolRepository
    {
        public RolRepository(ApplicationDbContext context) : base(context) { }
    }
}

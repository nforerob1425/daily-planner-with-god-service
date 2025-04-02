using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class ApplicationConfigRepository : Repository<ApplicationConfig>, IApplicationConfigRepository
    {
        public ApplicationConfigRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

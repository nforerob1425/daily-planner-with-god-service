using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class AdsRepository : Repository<Ads>, IAdsRepository
    {
        public AdsRepository(ApplicationDbContext context) : base (context)    
        {
        }
    }
}

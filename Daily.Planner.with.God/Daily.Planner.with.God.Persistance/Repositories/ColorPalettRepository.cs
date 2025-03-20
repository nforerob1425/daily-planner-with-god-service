using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class ColorPalettRepository : Repository<ColorPalett>, IColorPalettRepository
    {

        public ColorPalettRepository(ApplicationDbContext context) : base(context) { }
    }
}

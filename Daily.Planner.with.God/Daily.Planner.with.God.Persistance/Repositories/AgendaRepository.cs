using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class AgendaRepository : Repository<Agenda>, IAgendaRepository
    {
        private readonly ApplicationDbContext _context;
        public AgendaRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<ResponseMessage<List<Agenda>>> GetAgendasAsync(bool isMale)
        {
            var response = new ResponseMessage<List<Agenda>>();
            try
            {
                var agendas = await _context.Agendas.Where(a => a.IsMale == isMale).ToListAsync();
                response = new ResponseMessage<List<Agenda>>
                {
                    Data = agendas,
                    Message = "Agendas found",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting Agendas, Error: {ex.Message}";
                response.Success = false;
            }
            return response;
        }
    }
}

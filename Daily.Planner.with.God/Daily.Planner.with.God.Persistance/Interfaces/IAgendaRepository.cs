using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Persistance.Interfaces
{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        Task<ResponseMessage<List<Agenda>>> GetAgendasAsync(bool isMale);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IAgendaService
    {
        Task<ResponseMessage<List<Agenda>>> GetAgendasAsync();
        Task<ResponseMessage<List<Agenda>>> GetAgendasAsync(bool isMale);
        Task<ResponseMessage<Agenda?>> GetAgendaAsync(Guid id);
        Task<ResponseMessage<Agenda>> CreateAgendaAsync(Agenda agenda);
        Task<ResponseMessage<bool>> UpdateAgendaAsync(Agenda agenda);
        Task<ResponseMessage<bool>> DeleteAgendaAsync(Guid id);
    }
}

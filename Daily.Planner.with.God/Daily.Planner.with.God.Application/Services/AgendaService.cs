using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<ResponseMessage<List<Agenda>>> GetAgendasAsync(bool isMale)
        {
            try
            {
                return await _agendaRepository.GetAgendasAsync(isMale);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<Agenda?>> GetAgendaAsync(Guid id)
        {
            try
            {
                return await _agendaRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<Agenda>> CreateAgendaAsync(Agenda agenda)
        {
            try
            {
                agenda.Id = Guid.NewGuid();
                return await _agendaRepository.CreateAsync(agenda);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> UpdateAgendaAsync(Agenda agenda)
        {
            try
            {
                return await _agendaRepository.UpdateAsync(agenda);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteAgendaAsync(Guid id)
        {
            try
            {
                return await _agendaRepository.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

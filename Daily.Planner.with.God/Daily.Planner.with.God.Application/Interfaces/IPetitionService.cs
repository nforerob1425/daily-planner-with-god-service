using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IPetitionService
    {
        Task<ResponseMessage<List<Petition>>> GetPetitionsAsync();
        Task<ResponseMessage<List<Petition>>> GetPetitionsAsync(Guid userId);
        Task<ResponseMessage<List<Petition>>> GetPetitionsByLeadIdAsync(Guid leadId);
        Task<ResponseMessage<Petition?>> GetPetitionAsync(Guid id);
        Task<ResponseMessage<Petition>> CreatePetitionAsync(Petition type);
        Task<ResponseMessage<bool>> UpdatePetitionAsync(Petition type);
        Task<ResponseMessage<bool>> DeletePetitionAsync(Guid id);
    }
}

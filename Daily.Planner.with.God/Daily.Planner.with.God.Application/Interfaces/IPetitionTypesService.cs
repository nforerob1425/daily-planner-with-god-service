using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IPetitionTypesService
    {
        Task<ResponseMessage<List<PetitionType>>> GetPetitionTypesAsync();
        Task<ResponseMessage<PetitionType?>> GetPetitionTypeAsync(Guid id);
        Task<ResponseMessage<PetitionType>> CreatePetitionTypeAsync(PetitionType petitionType);
        Task<ResponseMessage<bool>> UpdatePetitionTypeAsync(PetitionType petitionType);
        Task<ResponseMessage<bool>> DeletePetitionTypeAsync(Guid id);
    }
}

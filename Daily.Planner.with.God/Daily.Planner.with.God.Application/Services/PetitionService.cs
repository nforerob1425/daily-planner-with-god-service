using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class PetitionService : IPetitionService
    {
        private readonly IPetitionRepository _petitionRepository;

        public PetitionService(IPetitionRepository petitionRepository)
        {
            _petitionRepository = petitionRepository;
        }

        public async Task<ResponseMessage<List<Petition>>> GetPetitionsAsync()
        {
            try
            {
                return await _petitionRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<List<Petition>>> GetPetitionsAsync(Guid userId)
        {
            try
            {
                return await _petitionRepository.GetAllPetitionsByUserId(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<List<Petition>>> GetPetitionsByLeadIdAsync(Guid userId)
        {
            try
            {
                return await _petitionRepository.GetAllPetitionsByLeadId(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<Petition?>> GetPetitionAsync(Guid id)
        {
            try
            {
                return await _petitionRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<Petition>> CreatePetitionAsync(Petition petition)
        {
            try
            {
                petition.Id = Guid.NewGuid();
                return await _petitionRepository.CreateAsync(petition);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<bool>> UpdatePetitionAsync(Petition petition)
        {
            try
            {
                return await _petitionRepository.UpdateAsync(petition);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeletePetitionAsync(Guid id)
        {
            try
            {
                return await _petitionRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

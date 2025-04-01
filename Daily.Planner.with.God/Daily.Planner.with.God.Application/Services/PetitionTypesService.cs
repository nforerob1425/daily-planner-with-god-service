using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class PetitionTypesService : IPetitionTypesService
    {
        private readonly IPetitionTypeRepository _petitionTypeRepository;
        public PetitionTypesService(IPetitionTypeRepository petitionTypeRepository)
        {
            _petitionTypeRepository = petitionTypeRepository;
        }

        public async Task<ResponseMessage<PetitionType>> CreatePetitionTypeAsync(PetitionType petitionType)
        {
            try
            {
                var petitionTypeCreated = await _petitionTypeRepository.CreateAsync(petitionType);
                return petitionTypeCreated;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeletePetitionTypeAsync(Guid id)
        {
            try
            {
                var petition = await _petitionTypeRepository.DeleteAsync(id);
                return petition;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<PetitionType?>> GetPetitionTypeAsync(Guid id)
        {
            try
            {
                var petition = await _petitionTypeRepository.GetByIdAsync(id);
                return petition;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<List<PetitionType>>> GetPetitionTypesAsync()
        {
            try
            {
                var allPetitions = await _petitionTypeRepository.GetAllAsync();
                return allPetitions;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> UpdatePetitionTypeAsync(PetitionType petitionType)
        {
            try
            {
                var petitionUpdated = await _petitionTypeRepository.UpdateAsync(petitionType);
                return petitionUpdated;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

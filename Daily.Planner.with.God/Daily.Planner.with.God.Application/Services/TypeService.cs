using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Persistance.Interfaces;
using Type = Daily.Planner.with.God.Domain.Entities.Type;

namespace Daily.Planner.with.God.Application.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<ResponseMessage<List<Type>>> GetTypesAsync()
        {
            try
            {
                return await _typeRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<Type?>> GetTypeAsync(Guid id)
        {
            try
            {
                return await _typeRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<Type>> CreateTypeAsync(Type type)
        {
            try
            {
                type.Id = Guid.NewGuid();
                return await _typeRepository.CreateAsync(type);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<bool>> UpdateTypeAsync(Type type)
        {
            try
            {
                return await _typeRepository.UpdateAsync(type);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteTypeAsync(Guid id)
        {
            try
            {
                return await _typeRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

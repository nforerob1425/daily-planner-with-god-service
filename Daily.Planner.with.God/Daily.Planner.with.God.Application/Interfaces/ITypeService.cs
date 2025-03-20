using Daily.Planner.with.God.Common;
using Type = Daily.Planner.with.God.Domain.Entities.Type;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface ITypeService
    {
        Task<ResponseMessage<List<Type>>> GetTypesAsync();
        Task<ResponseMessage<Type?>> GetTypeAsync(Guid id);
        Task<ResponseMessage<Type>> CreateTypeAsync(Type type);
        Task<ResponseMessage<bool>> UpdateTypeAsync(Type type);
        Task<ResponseMessage<bool>> DeleteTypeAsync(Guid id);
    }
}

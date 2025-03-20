using Daily.Planner.with.God.Common;

namespace Daily.Planner.with.God.Persistance.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<ResponseMessage<List<T>>> GetAllAsync();
        Task<ResponseMessage<T?>> GetByIdAsync(Guid id);
        Task<ResponseMessage<T>> CreateAsync(T entity);
        Task<ResponseMessage<bool>> UpdateAsync(T entity);
        Task<ResponseMessage<bool>> DeleteAsync(Guid id);
    }
}

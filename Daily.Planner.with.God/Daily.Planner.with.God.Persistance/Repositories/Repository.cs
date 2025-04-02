using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseMessage<List<T>>> GetAllAsync()
        {
            var response = new ResponseMessage<List<T>>();
            try
            {
                var entities = await _context.Set<T>().ToListAsync();
                response = new ResponseMessage<List<T>>
                {
                    Data = entities,
                    Message = $"{typeof(T).Name} found",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting {typeof(T).Name}s, Error: {ex.Message}";
                response.Success = false;
            }

            return response;
        }

        public async Task<ResponseMessage<T?>> GetByIdAsync(Guid id)
        {
            var response = new ResponseMessage<T?>();
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                response = new ResponseMessage<T?>
                {
                    Data = entity,
                    Message = entity == null ? $"{typeof(T).Name} not found with id: {id}" : $"{typeof(T).Name} found",
                    Success = entity != null
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting {typeof(T).Name}: {id}, Error: {ex.Message}";
                response.Success = false;
            }

            return response;
        }

        public async Task<ResponseMessage<T>> CreateAsync(T entity)
        {
            var response = new ResponseMessage<T>
            {
                Data = entity
            };

            try
            {
                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                response.Message = $"{typeof(T).Name} created";
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = $"Error creating {typeof(T).Name}, Error: {ex.Message}";
                response.Success = false;
            }
            return response;
        }

        public async Task<ResponseMessage<bool>> UpdateAsync(T entity)
        {
            var response = new ResponseMessage<bool>();
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                response.Data = true;
                response.Success = true;
                response.Message = $"{typeof(T).Name} updated";
                
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error updating {typeof(T).Name}, Error: {ex.Message}";
            }

            return response;
        }

        public async Task<ResponseMessage<bool>> DeleteAsync(Guid id)
        {
            var response = new ResponseMessage<bool>();
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                {
                    response.Data = false;
                    response.Success = true;
                    response.Message = $"{typeof(T).Name} not found";
                }
                else
                {
                    _context.Set<T>().Remove(entity);
                    await _context.SaveChangesAsync();
                    response.Data = true;
                    response.Success = true;
                    response.Message = $"{typeof(T).Name} deleted";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error deleting {typeof(T).Name}: {id}, Error: {ex.Message}";

                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    response.Message += $" | InnerError: {inner.Message}";
                    inner = inner.InnerException;
                }
            }

            return response;
        }
    }
}

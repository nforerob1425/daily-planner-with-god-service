using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Persistance.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByUserNameAsync(string username);
        Task<List<User>> GetSheepUsersAsync(Guid leadUserId);
    }
}

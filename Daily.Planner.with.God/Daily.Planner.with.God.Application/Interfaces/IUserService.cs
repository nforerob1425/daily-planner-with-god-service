using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IUserService
    {
        Task<ResponseMessage<List<User>>> GetUsersAsync();
        Task<ResponseMessage<User?>> GetUserAsync(Guid id);
        Task<ResponseMessage<User>> CreateUserAsync(User user);
        Task<ResponseMessage<bool>> UpdateUserAsync(User user);
        Task<ResponseMessage<bool>> DeleteUserAsync(Guid id);
    }
}

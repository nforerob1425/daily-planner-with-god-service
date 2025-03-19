using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IRolService
    {
        Task<ResponseMessage<List<Rol>>> GetRolesAsync();
        Task<ResponseMessage<Rol?>> GetRoleAsync(Guid id);
        Task<ResponseMessage<Rol>> CreateRoleAsync(Rol role);
        Task<ResponseMessage<bool>> UpdateRoleAsync(Rol role);
        Task<ResponseMessage<bool>> DeleteRoleAsync(Guid id);
    }
}

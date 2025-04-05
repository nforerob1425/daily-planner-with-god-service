using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IRolService
    {
        Task<ResponseMessage<List<Role>>> GetRolesAsync();
        Task<ResponseMessage<Role?>> GetRoleAsync(Guid id);
    }
}

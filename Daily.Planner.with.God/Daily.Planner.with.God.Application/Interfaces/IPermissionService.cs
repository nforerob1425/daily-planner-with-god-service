using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IPermissionService
    {
        Task<ResponseMessage<List<Permission>>> GetPermissionsAsync();
        Task<ResponseMessage<Permission?>> GetPermissionAsync(Guid id);
        Task<ResponseMessage<Permission>> CreatePermissionAsync(Permission permission);
        Task<ResponseMessage<bool>> UpdatePermissionAsync(Permission permission);
        Task<ResponseMessage<bool>> DeletePermissionAsync(Guid id);
    }
}

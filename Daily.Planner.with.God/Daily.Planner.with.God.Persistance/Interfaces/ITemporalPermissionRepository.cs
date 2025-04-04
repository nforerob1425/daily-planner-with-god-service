using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Persistance.Interfaces
{
    public interface ITemporalPermissionRepository
    {
        Task<ResponseMessage<List<TemporalPermission>>> GetAllAsync();
        Task<ResponseMessage<TemporalPermission>> CreateAsync(TemporalPermission entity);
        Task<ResponseMessage<bool>> DeleteAsync(Guid id);
        Task<ResponseMessage<List<TemporalPermission>>> GetByRoleIdAsync(Guid roleId);
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionService(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<ResponseMessage<List<Permission>>> GetPermissionsAsync()
        {
            try
            {
                return await _permissionRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<Permission?>> GetPermissionAsync(Guid id)
        {
            try
            {
                return await _permissionRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

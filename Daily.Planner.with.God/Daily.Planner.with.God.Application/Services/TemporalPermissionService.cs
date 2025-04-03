using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;
using Daily.Planner.with.God.Persistance.Repositories;

namespace Daily.Planner.with.God.Application.Services
{
    public class TemporalPermissionService : ITemporalPermissionService
    {
        private readonly ITemporalPermissionRepository _temporalPermissionRepository;

        public TemporalPermissionService(ITemporalPermissionRepository temporalPermissionRepository)
        {
            _temporalPermissionRepository = temporalPermissionRepository;
        }

        public async Task<ResponseMessage<List<TemporalPermission>>> GetAllAsync()
        {
            try
            {
                return await _temporalPermissionRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<TemporalPermission>> CreateAsync(TemporalPermission type)
        {
            try
            {
                type.Id = Guid.NewGuid();
                return await _temporalPermissionRepository.CreateAsync(type);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteAsync(Guid id)
        {
            try
            {
                return await _temporalPermissionRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

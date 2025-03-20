using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;

        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<ResponseMessage<List<Role>>> GetRolesAsync()
        {
            try
            {
                return await _rolRepository.GetAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<Role?>> GetRoleAsync(Guid id)
        {
            try
            {
                return await _rolRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<Role>> CreateRoleAsync(Role role)
        {
            try
            {
                role.Id = Guid.NewGuid();
                return await _rolRepository.CreateAsync(role);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<bool>> UpdateRoleAsync(Role role)
        {
            try
            {
                return await _rolRepository.UpdateAsync(role);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteRoleAsync(Guid id)
        {
            try
            {
                return await _rolRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITemporalPermissionRepository _temporalPermissionRepository;
        private readonly IPermissionRepository _permissionRepository;

        public UserService(IUserRepository userRepository, ITemporalPermissionRepository temporalPermissionRepository , IPermissionRepository permissionRepository)
        {
            _userRepository = userRepository;
            _temporalPermissionRepository = temporalPermissionRepository;
            _permissionRepository = permissionRepository;
        }

        public async Task<ResponseMessage<List<User>>> GetUsersAsync()
        {
            try
            {
                return await _userRepository.GetAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<User?>> GetUserAsync(Guid id)
        {
            try
            {
                return await _userRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<User>> CreateUserAsync(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                return await _userRepository.CreateAsync(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> UpdateUserAsync(User user)
        {
            try
            {
                return await _userRepository.UpdateAsync(user);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteUserAsync(Guid id)
        {
            try
            {
                return await _userRepository.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _userRepository.GetUserByUserNameAsync(username);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> ValidAccessPermissionAsync(Guid userId, List<string> permissionValues)
        {
            try
            {
                var permisions = new List<string>();
                var response = false;
                var userData = await _userRepository.GetByIdAsync(userId);

                if (userData.Success)
                {
                    permisions = await GetPermissionsByRoleId(userData.Data.RoleId);

                    foreach (var permission in permissionValues)
                    {
                        if (permisions.Contains(permission))
                        {
                            response = true;
                        }
                        else
                        {
                            response = false;
                            break;
                        }
                    }
                    
                }

                return response;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<string>> GetPermissionsByRoleId(Guid roleId)
        {
            try
            {
                var permisions = new List<string>();
                
                var tpData = await _temporalPermissionRepository.GetByRoleIdAsync(roleId);
                if (tpData.Success)
                {
                    foreach (var item in tpData.Data)
                    {
                        var permissionData = await _permissionRepository.GetByIdAsync(item.PermissionId);
                        if (permissionData.Success && permissionData.Data != null)
                        {
                            permisions.Add(permissionData.Data.SystemName);
                        }
                    }
                }
                
                return permisions;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

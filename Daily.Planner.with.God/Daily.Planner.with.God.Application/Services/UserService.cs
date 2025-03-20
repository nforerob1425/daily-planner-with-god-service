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

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
    }
}

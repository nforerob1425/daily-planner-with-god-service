using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class ApplicationConfigServices : IApplicationConfigServices
    {
        private readonly IApplicationConfigRepository _applicationConfigRepository;

        public ApplicationConfigServices(IApplicationConfigRepository applicationConfigRepository)
        {
            _applicationConfigRepository = applicationConfigRepository;
        }

        public async Task<ResponseMessage<ApplicationConfig>> CreateApplicationConfigAsync(ApplicationConfig appConfig)
        {
            try
            {
                var created = await _applicationConfigRepository.CreateAsync(appConfig);
                return created;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteApplicationConfigAsync(Guid id)
        {
            try
            {
                var deleted = await _applicationConfigRepository.DeleteAsync(id);
                return deleted;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<ApplicationConfig?>> GetApplicationConfigAsync(Guid id)
        {
            try
            {
                var appConfig = await _applicationConfigRepository.GetByIdAsync(id);
                return appConfig;
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public async Task<ResponseMessage<List<ApplicationConfig>>> GetApplicationConfigsAsync()
        {
            try
            {
                var appConfigs = await _applicationConfigRepository.GetAllAsync();
                return appConfigs;
            }
            catch (Exception)
            {

                throw;
            }            
        }

        public async Task<ResponseMessage<bool>> UpdateApplicationConfigAsync(ApplicationConfig appConfig)
        {
            try
            {
                var updated = await _applicationConfigRepository.UpdateAsync(appConfig);
                return updated;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

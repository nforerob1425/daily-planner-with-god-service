using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public async Task<ResponseMessage<List<Configuration>>> GetConfigurationsAsync()
        {
            try
            {
                return await _configurationRepository.GetAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<Configuration?>> GetConfigurationAsync(Guid id)
        {
            try
            {
                return await _configurationRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<Configuration>> CreateConfigurationAsync(Configuration configuration)
        {
            try
            {
                configuration.Id = Guid.NewGuid();
                return await _configurationRepository.CreateAsync(configuration);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> UpdateConfigurationAsync(Configuration configuration)
        {
            try
            {
                return await _configurationRepository.UpdateAsync(configuration);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteConfigurationAsync(Guid id)
        {
            try
            {
                return await _configurationRepository.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

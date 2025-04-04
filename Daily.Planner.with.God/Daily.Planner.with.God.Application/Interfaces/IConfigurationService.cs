﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IConfigurationService
    {
        Task<ResponseMessage<List<Configuration>>> GetConfigurationsAsync();
        Task<ResponseMessage<Configuration?>> GetConfigurationAsync(Guid id);
        Task<ResponseMessage<Configuration>> CreateConfigurationAsync(Configuration configuration);
        Task<ResponseMessage<bool>> UpdateConfigurationAsync(Configuration configuration);
        Task<ResponseMessage<bool>> DeleteConfigurationAsync(Guid id);
    }
}

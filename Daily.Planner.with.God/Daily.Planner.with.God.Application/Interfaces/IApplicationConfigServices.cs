using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IApplicationConfigServices
    {
        Task<ResponseMessage<List<ApplicationConfig>>> GetApplicationConfigsAsync();
        Task<ResponseMessage<bool>> UpdateApplicationConfigAsync(ApplicationConfig appConfig);
    }
}

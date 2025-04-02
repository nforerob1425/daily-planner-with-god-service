using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface IAdsService
    {
        Task<ResponseMessage<List<Ads>>> GetAdsAsync();
        Task<ResponseMessage<List<Ads>>> GetAdsAsync(Guid userId);
        Task<ResponseMessage<Ads?>> GetAdAsync(Guid id);
        Task<ResponseMessage<Ads>> CreateAdAsync(Ads ad);
        Task<ResponseMessage<bool>> UpdateAdAsync(Ads ad);
        Task<ResponseMessage<bool>> DeleteAdAsync(Guid id);
    }
}

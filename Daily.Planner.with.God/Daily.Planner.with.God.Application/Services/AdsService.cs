using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class AdsService : IAdsService
    {
        private readonly IAdsRepository _adsRepository;

        public AdsService(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        public async Task<ResponseMessage<List<Ads>>> GetAdsAsync()
        {
            try
            {
                return await _adsRepository.GetAllAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<Ads?>> GetAdAsync(Guid id)
        {
            try
            {
                return await _adsRepository.GetByIdAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<Ads>> CreateAdAsync(Ads ad)
        {
            try
            {

                ad.Id = Guid.NewGuid();
                return await _adsRepository.CreateAsync(ad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> UpdateAdAsync(Ads ad)
        {
            try
            {

                return await _adsRepository.UpdateAsync(ad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteAdAsync(Guid id)
        {
            try
            {
                return await _adsRepository.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

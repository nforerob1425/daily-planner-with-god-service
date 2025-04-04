using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class AdsRepository : Repository<Ads>, IAdsRepository
    {
        private readonly ApplicationDbContext _context;
        public AdsRepository(ApplicationDbContext context) : base (context)    
        {
            _context = context;
        }

        public async Task<ResponseMessage<List<Ads>>> GetAllAsync(Guid userId)
        {
            var response = new ResponseMessage<List<Ads>>();
            try
            {
                DateTime now = DateTime.UtcNow;
                List<Ads> ads = new List<Ads>();

                var currentUser = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
                
                if (currentUser.LeadId == null)
                {
                    ads = await _context.Ads
                                        .Where(a =>
                                            ((a.UserCreatedId == currentUser.Id || a.UserCreatedId == currentUser.LeadId)
                                            &&
                                            a.EndDate >= now && a.StartDate <= now)
                                            ||
                                            (a.IsGlobal && (a.EndDate >= now && a.StartDate <= now))
                                        )
                                        .ToListAsync();
                }
                else 
                {
                    ads = await _context.Ads
                                        .Where(a =>
                                            ((a.UserCreatedId == currentUser.Id || a.UserCreatedId == currentUser.LeadId)
                                            &&
                                            a.EndDate >= now && a.StartDate <= now)
                                            ||
                                            (a.IsGlobal && (a.EndDate >= now && a.StartDate <= now))
                                        )
                                        .ToListAsync();
                }
                 
                response = new ResponseMessage<List<Ads>>
                {
                    Data = ads,
                    Message = $"{typeof(Ads).Name} found",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting {typeof(Ads).Name}s, Error: {ex.Message}";
                response.Success = false;
            }

            return response;
        }

        public async Task<ResponseMessage<List<Ads>>> GetAlByUserIdAsync(Guid userId)
        {
            var response = new ResponseMessage<List<Ads>>();
            try
            {
                DateTime now = DateTime.UtcNow;
                List<Ads> ads = new List<Ads>();
                
                ads = await _context.Ads.Where(a => a.UserCreatedId == userId).ToListAsync();

                response = new ResponseMessage<List<Ads>>
                {
                    Data = ads,
                    Message = $"{typeof(Ads).Name} found",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting {typeof(Ads).Name}s, Error: {ex.Message}";
                response.Success = false;
            }

            return response;
        }
    }
}

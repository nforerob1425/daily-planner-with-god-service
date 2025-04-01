using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class PetitionRepository : Repository<Petition>, IPetitionRepository
    {
        private readonly ApplicationDbContext _context;
        public PetitionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ResponseMessage<List<Petition>>> GetAllPetitionsByUserId(Guid userId)
        {
            var response = new ResponseMessage<List<Petition>>();
            try
            {
                var petitions = _context.Petitions.Where(c => c.UserId == userId).ToList();
                response = new ResponseMessage<List<Petition>>
                {
                    Data = petitions,
                    Message = $"Cards found for user: {userId}",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting cards for user: {userId}, Error: {ex.Message}";
                response.Success = false;
            }
            return response;
        }

        public async Task<ResponseMessage<List<Petition>>> GetAllPetitionsByLeadId(Guid userId)
        {
            var response = new ResponseMessage<List<Petition>>();
            try
            {
                var petitions = _context.Petitions.Where(c => c.ReportedToUserId == userId).ToList();
                response = new ResponseMessage<List<Petition>>
                {
                    Data = petitions,
                    Message = $"Cards found for user: {userId}",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                response.Message = $"Error getting cards for user: {userId}, Error: {ex.Message}";
                response.Success = false;
            }
            return response;
        }
    }
}

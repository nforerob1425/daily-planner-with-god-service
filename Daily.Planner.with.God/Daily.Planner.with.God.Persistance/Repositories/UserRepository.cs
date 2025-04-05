using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<List<User>> GetSheepUsersAsync(Guid leadUserId)
        {
            return await _context.Users.Where(u => u.LeadId == leadUserId).ToListAsync();
        }

        public async Task<User?> GetUserByUserNameAsync(string username)
        {
            return _context.Users.Where(u => u.Username == username).FirstOrDefault();
        }
    }
}

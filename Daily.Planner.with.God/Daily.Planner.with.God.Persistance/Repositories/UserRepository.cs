using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<User?> GetUserByUserNameAsync(string username)
        {
            return _context.Users.Where(u => u.Username == username).FirstOrDefault();
        }
    }
}

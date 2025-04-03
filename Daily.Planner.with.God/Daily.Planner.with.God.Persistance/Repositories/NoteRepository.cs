using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance.Repositories
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        private readonly ApplicationDbContext _context;
        public NoteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ResponseMessage<List<Note>>> GetAllNotesByUserId(Guid userId, Guid agendaId)
        {
            var response = new ResponseMessage<List<Note>>();
            try
            {
                var notes =  await _context.Notes.Where(c => c.UserId == userId && c.AgendaId == agendaId).ToListAsync();
                response = new ResponseMessage<List<Note>>
                {
                    Data = notes,
                    Message = $"Notes found for user: {userId}",
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

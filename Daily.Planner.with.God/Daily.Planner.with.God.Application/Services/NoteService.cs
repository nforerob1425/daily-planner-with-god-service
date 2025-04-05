using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Daily.Planner.with.God.Persistance.Interfaces;

namespace Daily.Planner.with.God.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public async Task<ResponseMessage<Note>> CreateNoteAsync(Note note)
        {
            try
            {
                note.Id = Guid.NewGuid();
                var created = await _noteRepository.CreateAsync(note);
                return created;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> DeleteNoteAsync(Guid id)
        {
            try
            {
                var deleted = await _noteRepository.DeleteAsync(id);
                return deleted;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<List<Note>>> GetNotesAsync()
        {
            try
            {
                var notes = await _noteRepository.GetAllAsync();
                return notes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<List<Note>>> GetNotesAsync(Guid userId)
        {
            try
            {
                var notes = await _noteRepository.GetAllNotesByUserId(userId);
                return notes;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<List<Note>>> GetNotesAsync(Guid userId, Guid agendaId)
        {
            try
            {
                var note = await _noteRepository.GetAllNotesByUserIdAndAgendaId(userId, agendaId);
                return note;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ResponseMessage<bool>> UpdateNoteAsync(Note note)
        {
            try
            {
                var updated = await _noteRepository.UpdateAsync(note);
                return updated;
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}

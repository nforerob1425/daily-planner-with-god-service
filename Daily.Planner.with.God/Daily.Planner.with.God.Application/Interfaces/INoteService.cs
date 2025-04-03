using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Interfaces
{
    public interface INoteService
    {
        Task<ResponseMessage<List<Note>>> GetNotesAsync();
        Task<ResponseMessage<List<Note>>> GetNotesAsync(Guid userId, Guid agendaId);
        Task<ResponseMessage<Note?>> GetNoteAsync(Guid id);
        Task<ResponseMessage<Note>> CreateNoteAsync(Note note);
        Task<ResponseMessage<bool>> UpdateNoteAsync(Note note);
        Task<ResponseMessage<bool>> DeleteNoteAsync(Guid id);
    }
}

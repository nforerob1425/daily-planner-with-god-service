using Daily.Planner.with.God.Application.Dtos;
using Daily.Planner.with.God.Application.Interfaces;
using Daily.Planner.with.God.Common;
using Daily.Planner.with.God.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Daily.Planner.with.God.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IUserService _userService;
        private readonly IAgendaService _agendaService;
        public NoteController(INoteService noteService, IUserService userService, IAgendaService agendaService)
        {
            _noteService = noteService;
            _userService = userService;
            _agendaService = agendaService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage<List<Note>>>> GetAllNotesByUserId([FromQuery] Guid AgendaId)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CSNT"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                try
                {
                    Guid userId = Guid.Parse(currentUserId.ToString());
                    var notesData = await _noteService.GetNotesAsync(userId, AgendaId);
                    return Ok(notesData);
                }
                catch (Exception)
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
            
        }


        [HttpPut]
        public async Task<ActionResult<ResponseMessage<bool>>> UpdateNote(NoteUpdateDto noteToUpdate)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CUNT", "CSAG", "CSUS"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var note = new Note();
                var agendaData = await _agendaService.GetAgendaAsync(noteToUpdate.AgendaId);
                var userData = await _userService.GetUserAsync(noteToUpdate.UserId);

                if (userData.Success && agendaData.Success)
                {
                    note.Agenda = agendaData.Data;
                    note.User = userData.Data;
                    note.AgendaId = noteToUpdate.AgendaId;
                    note.UserId = noteToUpdate.UserId;
                    note.Content = noteToUpdate.Content;
                    note.Id = noteToUpdate.Id;
                }

                var updatedData = await _noteService.UpdateNoteAsync(note);
                return updatedData;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public async Task<ActionResult<ResponseMessage<Note>>> CreateNote(NoteCreateDto noteToCreate)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CCNT", "CSAG", "CSUS"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var note = new Note();
                var agendaData = await _agendaService.GetAgendaAsync(noteToCreate.AgendaId);
                var userData = await _userService.GetUserAsync(noteToCreate.UserId);

                if (userData.Success && agendaData.Success)
                {
                    note.Agenda = agendaData.Data;
                    note.User = userData.Data;
                    note.AgendaId = noteToCreate.AgendaId;
                    note.UserId = noteToCreate.UserId;
                    note.Content = noteToCreate.Content;
                }

                var createdData = await _noteService.CreateNoteAsync(note);
                return createdData;
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ResponseMessage<bool>>> DeleteNote(Guid noteId)
        {
            if (Request.Headers.TryGetValue("UserId", out var currentUserId))
            {
                Guid userIdToValid = Guid.Parse(currentUserId.ToString());
                var validAccess = await _userService.ValidAccessPermissionAsync(userIdToValid, ["CDNT"]);
                if (!validAccess)
                {
                    return Unauthorized();
                }

                var deletedData = await _noteService.DeleteNoteAsync(noteId);
                return deletedData;
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

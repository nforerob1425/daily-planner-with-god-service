using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class NoteCreateDto
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid AgendaId { get; set; }
    }
}

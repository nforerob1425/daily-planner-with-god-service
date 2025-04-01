using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class AgendaCreateDto
    {
        public int Year { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageBackgroundSrc { get; set; }
        public bool IsReported { get; set; }
       
        public bool IsMale { get; set; } = true;
        public Guid? OriginalAgendaId { get; set; }
    }
}

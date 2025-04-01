using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class Agenda
    {
        [Key]
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageBackgroundSrc { get; set; }
        public bool IsReported { get; set; }

        [JsonIgnore]
        public ICollection<Card> Cards { get; set; }
        public bool IsMale { get; set; } = true;
        public Guid? OriginalAgendaId { get; set; }

        [JsonIgnore]
        public Agenda OriginalAgenda { get; set; }
    }
}

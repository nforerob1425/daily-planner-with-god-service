using System.Text.Json.Serialization;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Guid AgendaId { get; set; }
        [JsonIgnore]
        public Agenda Agenda { get; set; }
    }
}

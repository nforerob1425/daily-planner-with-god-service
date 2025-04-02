using System.ComponentModel.DataAnnotations;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class ApplicationConfig
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}

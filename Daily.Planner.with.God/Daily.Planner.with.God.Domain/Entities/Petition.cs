using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class Petition
    {
        [Key]
        public Guid Id { get; set; }
        public string PrayFor { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPraying { get; set; }
        public Guid PetitionTypeId { get; set; }

        [JsonIgnore]
        public PetitionType PetitionType { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public Guid ReportedToUserId { get; set; }

        [JsonIgnore]
        public User ReportedToUser { get; set; }
    }
}

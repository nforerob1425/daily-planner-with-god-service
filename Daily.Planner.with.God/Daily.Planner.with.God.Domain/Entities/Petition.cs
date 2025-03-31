using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
        public PetitionType PetitionType { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ReportedToUserId { get; set; }
        public User ReportedToUser { get; set; }
    }
}

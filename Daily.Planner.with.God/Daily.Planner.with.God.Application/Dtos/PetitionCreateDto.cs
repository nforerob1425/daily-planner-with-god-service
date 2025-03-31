using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class PetitionCreateDto
    {
        public string PrayFor { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid PetitionTypeId { get; set; }
        public Guid UserId { get; set; }
        public Guid? ReportedToUserId { get; set; }
    }
}

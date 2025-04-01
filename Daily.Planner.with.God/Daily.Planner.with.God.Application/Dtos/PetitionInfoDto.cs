using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class PetitionInfoDto
    {
        public Guid Id { get; set; }
        public string PrayFor { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsPraying { get; set; }
        public Guid PetitionTypeId { get; set; }
        public string OriginalUser { get; set; }
        public Guid UserId { get; set; }
    }
}

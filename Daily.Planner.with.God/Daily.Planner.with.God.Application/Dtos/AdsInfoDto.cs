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
    public class AdsInfoDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsGlobal { get; set; }
        public Guid? UserCreatedId { get; set; }
        public string UserCreatedName { get; set; }
    }
}

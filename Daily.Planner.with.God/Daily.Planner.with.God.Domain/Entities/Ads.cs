using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class Ads
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsGlobal { get; set; }
        public Guid? UserCreatedId { get; set; }
        public User? UserCreated { get; set; }
    }
}

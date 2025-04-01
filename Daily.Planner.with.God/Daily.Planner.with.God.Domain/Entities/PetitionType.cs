using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class PetitionType
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
    }
}

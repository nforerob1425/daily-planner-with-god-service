using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class Configuration
    {
        [Key]
        public Guid Id { get; set; }
        public bool ShowFavorites { get; set; }
        public bool ShowPetitions { get; set; }
    }
}

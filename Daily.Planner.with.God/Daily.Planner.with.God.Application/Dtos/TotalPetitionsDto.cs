using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class TotalPetitionsDto
    {
        public int TotalPetitions { get; set; }
        public int PetitionsInPray { get; set; }
        public string TopOnePetitionType { get; set; } = string.Empty;
        public string TopTwoPetitionType { get; set; } = string.Empty;
        public string TopThreePetitionType { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class DashboardInfoDto
    {
        public TotalUsersDto Users { get; set; }
        public TotalCardsDto Cards { get; set; }
        public TotalPetitionsDto Petitions { get; set; }
        public int TotalAgendas { get; set; }
        public TotalColorsDto Colors { get; set; }
        public TotalRolesDto Roles { get; set; }
        public int TotalAds { get; set; }
        public int TotalNotes { get; set; }
    }
}

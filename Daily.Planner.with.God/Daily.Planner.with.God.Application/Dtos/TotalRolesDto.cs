using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class TotalRolesDto
    {
        public int TotalRolesExist { get; set; }
        public int TotalAdminUsers { get; set; }
        public int TotalModeratorUsers { get; set; }
        public List<string> RolesNames { get; set; }
    }
}

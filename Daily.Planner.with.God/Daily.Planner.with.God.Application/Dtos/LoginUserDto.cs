using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class LoginUserDto
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMale { get; set; }
        public Guid ConfigurationId { get; set; }
        public bool HasLead { get; set; }
        public List<string> Permissions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ConfigurationId { get; set; }
        public string Token { get; set; }
    }
}

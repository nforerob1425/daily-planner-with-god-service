using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid RoleId { get; set; }
        public Rol Role { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid ConfigurationId { get; set; }
        public Configuration Configuration { get; set; }
        public Guid LeadId { get; set; }
        public User? Lead { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}

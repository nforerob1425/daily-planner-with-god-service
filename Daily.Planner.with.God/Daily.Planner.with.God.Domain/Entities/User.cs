using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid RoleId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid ConfigurationId { get; set; }
        [JsonIgnore]
        public Configuration Configuration { get; set; }
        public Guid? LeadId { get; set; }
        [JsonIgnore]
        public User? Lead { get; set; }
        [JsonIgnore]
        public ICollection<Card> Cards { get; set; }
        public bool IsMale { get; set; } = true;
        [JsonIgnore]
        public ICollection<Ads> Ads { get; set; }
        [JsonIgnore]
        public ICollection<Note> Notes { get; set; }
    }
}

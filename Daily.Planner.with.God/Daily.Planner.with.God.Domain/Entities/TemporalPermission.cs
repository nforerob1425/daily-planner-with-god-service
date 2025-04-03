using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class TemporalPermission
    {
        [Key]
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
        [JsonIgnore]
        public Permission Permission { get; set; }
    }
}

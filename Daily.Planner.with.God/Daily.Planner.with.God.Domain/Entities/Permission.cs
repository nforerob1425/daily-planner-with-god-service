using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class Permission
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string SystemName { get; set; }
        [JsonIgnore]
        public ICollection<TemporalPermission> TemporalPermissions { get; set; }
    }
}

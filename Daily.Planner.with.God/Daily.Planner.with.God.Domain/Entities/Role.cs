using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Scale { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<TemporalPermission> TemporalPermissions { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class Permission
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid RoleId { get; set; }
        public Role Rol { get; set; }
        public string SystemName { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class Type
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

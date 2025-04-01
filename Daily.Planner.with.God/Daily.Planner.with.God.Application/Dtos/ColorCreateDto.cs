using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class ColorCreateDto
    {
        public Guid TypeId { get; set; }
        public string Color { get; set; }
    }
}

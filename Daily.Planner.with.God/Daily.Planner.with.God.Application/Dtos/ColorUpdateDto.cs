using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class ColorUpdateDto
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public string Color { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class AgendaInfoDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageBackgroundSrc { get; set; }
        public bool IsReported { get; set; }
    }
}

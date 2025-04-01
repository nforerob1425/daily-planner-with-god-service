using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class NewPasswordDto
    {
        public string NewPassword { get; set; }
        public Guid UserId { get; set; }
    }
}

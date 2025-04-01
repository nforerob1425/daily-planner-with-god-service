using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class UserConfigurationUpdateDto
    {
        public Guid UserId { get; set; }
        public Guid ConfigurationId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class TotalCardsDto
    {
        public int TotalCards { get; set; }
        public int ReportedCards { get; set; }
        public int FavoritesCards { get; set; }
        public int TotalCardsLastMonth { get; set; }
        public int TotalCardsLastYear { get; set; }
        public int TotalCardsYearBeforeLast { get; set; }
        public string TopOneColorSelected { get; set; } = string.Empty;
        public string TopTwoColorSelected { get; set; } = string.Empty;
        public string TopThreeColorSelected { get; set; } = string.Empty;
    }
}

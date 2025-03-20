using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class ColorPalett
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public Type Type { get; set; }
        public string Color { get; set; }
        public ICollection<Card> CardsPrimary { get; set; }
        public ICollection<Card> CardsLetter { get; set; }
        public ICollection<Card> CardsTitle { get; set; }
        public ICollection<Card> CardsPrimaryDate { get; set; }
        public ICollection<Card> CardsLetterDate { get; set; }

    }
}

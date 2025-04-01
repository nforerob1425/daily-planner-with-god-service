using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class ColorPalett
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }

        [JsonIgnore]
        public Type Type { get; set; }
        public string Color { get; set; }

        [JsonIgnore]
        public ICollection<Card> CardsPrimary { get; set; }
        [JsonIgnore]
        public ICollection<Card> CardsLetter { get; set; }
        [JsonIgnore]
        public ICollection<Card> CardsTitle { get; set; }
        [JsonIgnore]
        public ICollection<Card> CardsPrimaryDate { get; set; }
        [JsonIgnore]
        public ICollection<Card> CardsLetterDate { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.Planner.with.God.Domain.Entities
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Favorite { get; set; }

        public Guid PrimaryColorId { get; set; }
        public ColorPalett PrimaryColor { get; set; }

        public Guid LetterColorId { get; set; }
        public ColorPalett LetterColor { get; set; }

        public Guid TitleColorId { get; set; }
        public ColorPalett TitleColor { get; set; }

        public string Versicle { get; set; }

        public Guid PrimaryColorDateId { get; set; }
        public ColorPalett PrimaryColorDate { get; set; }

        public Guid LetterDateColorId { get; set; }
        public ColorPalett LetterDateColor { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid AgendaId { get; set; }
        public Agenda Agenda { get; set; }

        public Guid OriginalUserId { get; set; }
        public User OriginalUser { get; set; }
    }
}

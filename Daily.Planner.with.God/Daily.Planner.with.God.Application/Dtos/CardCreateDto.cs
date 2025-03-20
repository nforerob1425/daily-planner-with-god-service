namespace Daily.Planner.with.God.Application.Dtos
{
    public class CardCreateDto
    {
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public bool Favorite { get; set; }
        public Guid PrimaryColorId { get; set; }
        public Guid LetterColorId { get; set; }
        public Guid TitleColorId { get; set; }
        public string? Versicle { get; set; }
        public Guid PrimaryColorDateId { get; set; }
        public Guid LetterDateColorId { get; set; }
        public Guid UserId { get; set; }
        public Guid AgendaId { get; set; }
    }
}

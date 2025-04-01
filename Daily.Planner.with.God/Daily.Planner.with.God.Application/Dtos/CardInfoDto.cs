namespace Daily.Planner.with.God.Application.Dtos
{
    public class CardInfoDto
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string CreateDate { get; set; }
        public string MonthCreated { get; set; }
        public string DayCreated { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public bool Favorite { get; set; }
        public string PrimaryColor { get; set; }
        public string LetterColor { get; set; }
        public string TitleColor { get; set; }
        public string? Versicle { get; set; }
        public string PrimaryColorDate { get; set; }
        public string LetterDateColor { get; set; }
        public Guid UserId { get; set; }
        public Guid AgendaId { get; set; }
        public string OriginalUserFullName { get; set; }
        public bool Reported { get; set; }

    }
}

namespace Daily.Planner.with.God.Application.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Guid RoleId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid ConfigurationId { get; set; }
        public Guid? LeadId { get; set; }
    }
}

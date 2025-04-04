﻿namespace Daily.Planner.with.God.Application.Dtos
{
    public class UserCreateDto
    {
        public Guid? Id { get; set; }
        public string Username { get; set; }
        public Guid RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid? LeadId { get; set; }
        public bool IsMale { get; set; }
    }
}

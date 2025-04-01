using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daily.Planner.with.God.Domain.Entities;

namespace Daily.Planner.with.God.Application.Dtos
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ConfigurationName { get; set; }
        public Guid ConfigurationId { get; set; }
        public bool IsMale { get; set; }
        public bool HasLead { get; set; }
        public string? LeadFirstname { get; set; }
        public string? LeadLastName { get; set; }
        public bool? IsMaleLead { get; set; }
        public bool ShowFavorites { get; set; }
        public bool ShowPetitions { get; set; }
        public List<CardInfoDto?> FavoriteCards { get; set; }
        public int TotalCardsCreated { get; set; }
        public int TotalCardsReported { get; set; }
        public List<PetitionInfoDto> PetitionsReported { get; set; }
        public List<PetitionType> PetitionTypes { get; set; }
    }
}

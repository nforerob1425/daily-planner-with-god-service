using Daily.Planner.with.God.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Type = Daily.Planner.with.God.Domain.Entities.Type;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Card> Cards { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ColorPalett> ColorPaletts { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<Ads> Ads { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<Configuration> Configurations { get; set; }
    public DbSet<Agenda> Agendas { get; set; }
    public DbSet<Petition> Petitions { get; set; }
    public DbSet<PetitionType> PetitionTypes { get; set; }
    public DbSet<ApplicationConfig> ApplicationConfigs { get; set; }
    public DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>()
            .HasOne(c => c.Agenda)
            .WithMany(cp => cp.Cards)
            .HasForeignKey(c => c.AgendaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Card>()
            .HasOne(c => c.PrimaryColor)
            .WithMany(cp => cp.CardsPrimary)
            .HasForeignKey(c => c.PrimaryColorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Card>()
            .HasOne(c => c.LetterColor)
            .WithMany(cp => cp.CardsLetter)
            .HasForeignKey(c => c.LetterColorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Card>()
            .HasOne(c => c.TitleColor)
            .WithMany(cp => cp.CardsTitle)
            .HasForeignKey(c => c.TitleColorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Card>()
            .HasOne(c => c.PrimaryColorDate)
            .WithMany(cp => cp.CardsPrimaryDate)
            .HasForeignKey(c => c.PrimaryColorDateId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Card>()
            .HasOne(c => c.LetterDateColor)
            .WithMany(cp => cp.CardsLetterDate)
            .HasForeignKey(c => c.LetterDateColorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ColorPalett>()
            .HasOne(cp => cp.Type)
            .WithMany()
            .HasForeignKey(cp => cp.TypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Card>()
            .HasOne(c => c.User)
            .WithMany(r => r.Cards)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Card>()
            .HasOne(c => c.OriginalUser)
            .WithMany()
            .HasForeignKey(c => c.OriginalUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Configuration)
            .WithMany()
            .HasForeignKey(u => u.ConfigurationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Petition>()
            .HasOne(c => c.PetitionType)
            .WithMany()
            .HasForeignKey(c => c.PetitionTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ads>()
            .HasOne(c => c.UserCreated)
            .WithMany(r => r.Ads)
            .HasForeignKey(c => c.UserCreatedId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Note>()
            .HasOne(c => c.Agenda)
            .WithMany(cp => cp.Notes)
            .HasForeignKey(c => c.AgendaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Note>()
           .HasOne(c => c.User)
           .WithMany(r => r.Notes)
           .HasForeignKey(c => c.UserId)
           .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = Guid.Parse("26C52004-D441-48D8-8E00-E2CEA7E1D55A"), Name = "Admin", Scale = 100 },
            new Role { Id = Guid.Parse("448F0302-927A-4A9E-B8F7-2EA10CD434E4"), Name = "Moderador", Scale = 10 },
            new Role { Id = Guid.Parse("B671E630-E8FC-48B0-BB22-6C5B608173F9"), Name = "Pastor", Scale = 6 },
            new Role { Id = Guid.Parse("FDD6E043-EBA2-4087-9B70-A1AFDF654060"), Name = "Cabeza de red", Scale = 5 },
            new Role { Id = Guid.Parse("E48CA8B7-C812-4A6C-8BC1-0D0DDBE21E32"), Name = "Lider de red", Scale = 4 },
            new Role { Id = Guid.Parse("0EDEA2E2-B3E0-4445-B7B1-856B098250FE"), Name = "Coordinador de red", Scale = 3 },
            new Role { Id = Guid.Parse("E52ADA33-3AC0-445A-A307-7DF21BCFB719"), Name = "Lider", Scale = 2 },
            new Role { Id = Guid.Parse("0CC14AAC-9F7C-4F37-A7D2-01226D41B2D2"), Name = "Oveja", Scale = 1 }
        );

        modelBuilder.Entity<Type>().HasData(
            new Type { Id = Guid.Parse("84D0826E-CE9C-4A52-B27E-E7740E8F98E7"), Name = "Primary Background" },
            new Type { Id = Guid.Parse("DB0D60A6-E693-44EB-AE68-CC31719599AE"), Name = "Primary Letter" },
            new Type { Id = Guid.Parse("7E3DB5BD-C255-4795-8D3B-3F038F09A9BA"), Name = "Title" },
            new Type { Id = Guid.Parse("9659AD69-C5D3-4939-8702-AF2064D6F1FD"), Name = "Title Date" },
            new Type { Id = Guid.Parse("457978C7-36F9-4CE0-B511-C5146C80C22E"), Name = "Title Date Background" }
        );

        modelBuilder.Entity<ColorPalett>().HasData(
            new ColorPalett { Id = Guid.Parse("8F25DF6D-44F0-4985-8E56-9D193D9F4570"), TypeId = Guid.Parse("84D0826E-CE9C-4A52-B27E-E7740E8F98E7"), Color = "#114D7A" },
            new ColorPalett { Id = Guid.Parse("B06DDF08-6D80-433D-9599-97ED6AB805D4"), TypeId = Guid.Parse("DB0D60A6-E693-44EB-AE68-CC31719599AE"), Color = "#EAE9E6" },
            new ColorPalett { Id = Guid.Parse("498CA682-19B8-40BB-9C5A-2E5E99F0796E"), TypeId = Guid.Parse("7E3DB5BD-C255-4795-8D3B-3F038F09A9BA"), Color = "#A0D3FA" },
            new ColorPalett { Id = Guid.Parse("6626C294-EE9F-4105-B858-68E4A6BA3036"), TypeId = Guid.Parse("9659AD69-C5D3-4939-8702-AF2064D6F1FD"), Color = "#FAE1A0" },
            new ColorPalett { Id = Guid.Parse("836D62F8-DEA8-4BDC-856F-613DE2DD79EB"), TypeId = Guid.Parse("457978C7-36F9-4CE0-B511-C5146C80C22E"), Color = "#7A3F11" }
        );

        modelBuilder.Entity<Agenda>().HasData(
            new Agenda
            {
                Id = Guid.Parse("9656EC88-B900-4117-984F-74D2868A2A7C"),
                Year = 2025,
                Title = "R07-2025",
                Content = "Contenido para la agenda",
                ImageBackgroundSrc = "/assets/backgrounds/R07-2025.png",
                IsReported = false
            },
            new Agenda
            {
                Id = Guid.Parse("E345B2D8-1C47-405C-B762-7C8DC3D8388A"),
                Year = 2025,
                Title = "R07-2025",
                Content = "Contenido para la agenda",
                ImageBackgroundSrc = "/assets/backgrounds/R07-2025.png",
                IsReported = true
            }
        );

        modelBuilder.Entity<Configuration>().HasData(
            new Configuration
            {
                Id = Guid.Parse("788A03CD-2864-44B2-883A-4D137F737ADA"),
                ShowFavorites = false,
                ShowPetitions = false
            }
        );

        modelBuilder.Entity<PetitionType>().HasData(
            new PetitionType
            {
                Id = Guid.Parse("F345BA02-73C0-42F4-8093-047A1CD0FE5F"),
                Name = "Otro",
                Icon = "mdi-comment-question-outline",
                Color = "#FFFFFF"
            }
        );

        modelBuilder.Entity<ApplicationConfig>().HasData(
            new ApplicationConfig
            {
                Id = Guid.Parse("026F5F5C-97BC-4BF2-8B72-9D8D0B6B0694"),
                Name = "HomeVideoUrl",
                Value = "https://www.youtube.com/watch?v=Q9QoXR_5Qzs&list=PLt7-BTVbUMJne1HPcFvTt-Z8XxUSQCp0o"
            }
        );
    }
}

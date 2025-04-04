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
    public DbSet<TemporalPermission> TemporalPermissions { get; set; }

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

        modelBuilder.Entity<TemporalPermission>()
            .HasOne(c => c.Role)
            .WithMany(r => r.TemporalPermissions)
            .HasForeignKey(c => c.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TemporalPermission>()
            .HasOne(c => c.Permission)
            .WithMany(r => r.TemporalPermissions)
            .HasForeignKey(c => c.PermissionId)
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
            },
            new Configuration
            {
                Id = Guid.Parse("dde063f6-79da-4707-852c-62260ffb82af"),
                ShowFavorites = false,
                ShowPetitions = true
            },
            new Configuration
            {
                Id = Guid.Parse("24d897b2-e36c-4e3e-a60e-5075535f7352"),
                ShowFavorites = true,
                ShowPetitions = false
            },
            new Configuration
            {
                Id = Guid.Parse("ed187966-ffc8-4897-becc-619cfe584445"),
                ShowFavorites = true,
                ShowPetitions = true
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
            /* TODO agregar mas tipo de peticiones */
        );

        modelBuilder.Entity<ApplicationConfig>().HasData(
            new ApplicationConfig
            {
                Id = Guid.Parse("026F5F5C-97BC-4BF2-8B72-9D8D0B6B0694"),
                Name = "HomeVideoUrl",
                Value = "https://www.youtube.com/watch?v=Q9QoXR_5Qzs&list=PLt7-BTVbUMJne1HPcFvTt-Z8XxUSQCp0o"
            }
        );

        var permissions = new List<Permission>()
        {
            new Permission { Id = Guid.Parse("05958f1c-844a-43e9-9bcb-6667dad75670"), Description = "Puede ver la vista de Administracion de usuarios", SystemName = "CSUV", Priority = 4 },
            new Permission { Id = Guid.Parse("0678fae5-e577-4fd5-a759-ae3fb0fd9d6b"), Description = "Puede ver las agendas", SystemName = "CSAG", Priority = 2 },
            new Permission { Id = Guid.Parse("0a1f874b-af1c-4b3f-8d3e-2714eb2a6ca4"), Description = "Puede crear tarjetas", SystemName = "CCCD", Priority = 2 },
            new Permission { Id = Guid.Parse("0aaa962a-8d64-4515-9659-63e37f98c8ca"), Description = "Puede actualizar las configuraciones del sistema", SystemName = "CUAP", Priority = 4 },
            new Permission { Id = Guid.Parse("0fe9b79f-8bf5-4742-8284-5414494988b0"), Description = "Puede actualizar sus anuncios", SystemName = "CUNW", Priority = 3 },
            new Permission { Id = Guid.Parse("161ab07a-92d0-422e-a7df-20e69238dad7"), Description = "Puede actualizar usuarios", SystemName = "CUUS", Priority = 3 },
            new Permission { Id = Guid.Parse("19f3b0e7-cc0b-44ba-ad7f-3ad17bcc9949"), Description = "Puede ver la vista del R07",   SystemName = "CSPV", Priority = 1 },
            new Permission { Id = Guid.Parse("1f52010f-c57c-4031-a666-4ad9c4076404"), Description = "Puede actualizar peticiones", SystemName = "CUPT", Priority = 3 },
            new Permission { Id = Guid.Parse("24395707-0c33-42fe-bc05-39bd9b5e0485"), Description = "Puede crear anuncios", SystemName = "CCNW", Priority = 3 },
            new Permission { Id = Guid.Parse("2ad66724-24d7-4a86-b512-7cf5a4c4bfc3"), Description = "Puede asignar permisos temporales", SystemName = "CCTP", Priority = 4 },
            new Permission { Id = Guid.Parse("2dd17f8f-6e80-4e60-919d-e304b90d0f46"), Description = "Puede actualizar las configuraciones", SystemName = "CUCN", Priority = 3 },
            new Permission { Id = Guid.Parse("2f6a2460-7e0c-4677-a9a7-0c90ac88e2c7"), Description = "Puede eliminar peticiones", SystemName = "CDPT", Priority = 2 },
            new Permission { Id = Guid.Parse("348f5ae9-8ee7-40e1-bd13-0166e437ed1b"), Description = "Puede eliminar colores", SystemName = "CDCO", Priority = 4 },
            new Permission { Id = Guid.Parse("3bd9aa44-f431-43a6-8b0a-ca99b77d100c"), Description = "Puede eliminar tarjetas", SystemName = "CDCD", Priority = 2 },
            new Permission { Id = Guid.Parse("3fb76b0e-bcf6-45a0-a141-42873cff242c"), Description = "Puede ver las configuraciones del sistema", SystemName = "CSAP", Priority = 2 },
            new Permission { Id = Guid.Parse("410edf32-53fb-4242-9ca1-009ae499fcca"), Description = "Puede ver la vista de Solicitudes", SystemName = "CSEV", Priority = 1 },
            new Permission { Id = Guid.Parse("489facd4-0546-4e91-9d2d-26afc5e60080"), Description = "Puede ver la vista del Dashboard", SystemName = "CSDV", Priority = 4 },
            new Permission { Id = Guid.Parse("4f7c081e-b834-4fed-acfb-10d54e8c8f11"), Description = "Puede reportar tarjetas", SystemName = "CRCD", Priority = 2 },
            new Permission { Id = Guid.Parse("503fc79e-3f52-435b-9222-254c8c1fc738"), Description = "Puede ver la vista de Manejo de la aplicacion", SystemName = "CSMAV", Priority = 4 },
            new Permission { Id = Guid.Parse("54b2a2a2-eccb-4241-8ece-d4e5a9beebaa"), Description = "Puede actualizar colores", SystemName = "CUCO", Priority = 4 },
            new Permission { Id = Guid.Parse("54e3c968-e8d4-4b43-87d6-6351076e0093"), Description = "Puede eliminar usuarios", SystemName = "CDUS", Priority = 4 },
            new Permission { Id = Guid.Parse("588ec542-ed55-4e66-9215-1c9216c5c914"), Description = "Puede descargar el reporte del mes", SystemName = "CDWCD", Priority = 2 },
            new Permission { Id = Guid.Parse("5bada406-7bf0-41e7-8f6c-52f65760181c"), Description = "Puede ver la vista del Inicio", SystemName = "CSHV", Priority = 1 },
            new Permission { Id = Guid.Parse("6a088364-cfa7-4e7c-8a31-17cddc9f1370"), Description = "Puede ver los anuncios", SystemName = "CSNW", Priority = 2 },
            new Permission { Id = Guid.Parse("717a6cae-0844-4666-9621-c7082a8b9539"), Description = "Puede ver las configuraciones", SystemName = "CSCN", Priority = 2},
            new Permission { Id = Guid.Parse("72d1cb2c-30b0-4b6c-a9cd-d471940f7b93"), Description = "Puede ver los colores", SystemName = "CSCO", Priority = 2 },
            new Permission { Id = Guid.Parse("75cf41d2-ca8f-4cb0-a37c-e3b34ddcb8c9"), Description = "Puede crear usuarios", SystemName = "CCUS", Priority = 4 },
            new Permission { Id = Guid.Parse("7816c0b8-4db8-4a8b-b171-824a179709d2"), Description = "Puede ver las tarjetas del R07", SystemName = "CSCD", Priority = 2 },
            new Permission { Id = Guid.Parse("8682fd93-c365-48f6-a363-720fd272a589"), Description = "Puede ver los permisos temporales", SystemName = "CSTP", Priority = 4 },
            new Permission { Id = Guid.Parse("8cbaaf22-3f25-4e50-b4b9-cc5f4a78ba6c"), Description = "Puede crear agendas", SystemName = "CCAG", Priority = 4 },
            new Permission { Id = Guid.Parse("9054c555-4a30-495b-95d4-fff561ce11c6"), Description = "Puede crear notas", SystemName = "CCNT", Priority = 2 },
            new Permission { Id = Guid.Parse("90d0aaaf-793c-4cde-89ea-706cdd0c1a6d"), Description = "Puede actualizar notas", SystemName = "CUNT", Priority = 2 },
            new Permission { Id = Guid.Parse("929d0a6d-6b2d-4391-aa79-c4859b9cfa57"), Description = "Puede eliminar agendas", SystemName = "CDAG", Priority = 4 },
            new Permission { Id = Guid.Parse("a4f2229d-cd70-4c4f-a0fa-39e2f9e4a639"), Description = "Puede ver los usuarios", SystemName = "CSUS", Priority = 2 },
            new Permission { Id = Guid.Parse("b3deaccb-bd01-4cd6-a543-9a001a93101c"), Description = "Puede ver las peticiones", SystemName = "CSPT", Priority = 2 },
            new Permission { Id = Guid.Parse("ba75c802-413c-4209-abb5-d92fe883061c"), Description = "Puede desasignar permisos temporales", SystemName = "CDTP", Priority = 4 },
            new Permission { Id = Guid.Parse("bbb2b3dc-b3a5-4ce4-811c-7750cba00c59"), Description = "Puede eliminar notas", SystemName = "CDNT", Priority = 2 },
            new Permission { Id = Guid.Parse("c7f65971-5dcf-45e8-b146-3df6a710df2c"), Description = "Puede eliminar sus anuncios", SystemName = "CDNW", Priority = 3 },
            new Permission { Id = Guid.Parse("cbd3a20b-a12a-437d-b130-ef77cb174edf"), Description = "Puede ver la vista de las Configuraciones", SystemName = "CSCV", Priority = 3 },
            new Permission { Id = Guid.Parse("cc7d6a95-da2c-4eca-b0fd-7e711600027e"), Description = "Puede ver la vista del Perfil", SystemName = "CSPRV", Priority = 1 },
            new Permission { Id = Guid.Parse("d274575a-c4f2-4d0a-ab6a-c634fabf9c15"), Description = "Puede actualizar agendas", SystemName = "CUAG", Priority = 4 },
            new Permission { Id = Guid.Parse("dc508983-5917-4752-8ccc-1c6674234417"), Description = "Puede crear colores", SystemName = "CCCO", Priority = 4 },
            new Permission { Id = Guid.Parse("e7c19a6f-64d5-47a7-bb93-00aa103a884a"), Description = "Puede ver sus notas", SystemName = "CSNT", Priority = 2 },
            new Permission { Id = Guid.Parse("ee46d590-2457-4b01-95f1-3af291450552"), Description = "Puede crear peticiones", SystemName = "CCPT", Priority = 2 },
            new Permission { Id = Guid.Parse("f6042a14-5907-4a6e-9417-0519cc422160"), Description = "Puede actualizar tarjetas", SystemName = "CUCD", Priority = 2 },
            new Permission { Id = Guid.Parse("ffe00ecd-e320-4a9d-84d7-2d3b2d16aa7b"), Description = "Puede ver la vista de Manejar tus peticiones", SystemName = "CSPTV", Priority = 1 },
            new Permission { Id = Guid.Parse("96F97762-8B1E-46D8-8450-F52E85C2C2AC"), Description = "Puede ver la clasificacion de los colores", SystemName = "CSTC", Priority = 2 },
            new Permission { Id = Guid.Parse("95A80530-1B8A-4A6B-9C88-D0F57AD03FCB"), Description = "Puede cambiar su contraseña", SystemName = "CUPS", Priority = 2 },
            new Permission { Id = Guid.Parse("2A02728C-4408-4628-84BF-3B9650DF5705"), Description = "Puede ver los permisos del sistema", SystemName = "CSPM", Priority = 4 }
        };

        var temporalPermissions = new List<TemporalPermission>()
        {
            new TemporalPermission { Id = Guid.Parse("0577b25b-00d8-41d8-8166-f9561bc8c013"), PermissionId = Guid.Parse("cc7d6a95-da2c-4eca-b0fd-7e711600027e"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("0617f000-969c-490a-8a07-41b56172404d"), PermissionId = Guid.Parse("7816c0b8-4db8-4a8b-b171-824a179709d2"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("08712e8d-3df2-4dd0-a91a-8331df2aa13a"), PermissionId = Guid.Parse("e7c19a6f-64d5-47a7-bb93-00aa103a884a"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("09146e3a-c35f-4756-89fb-bb61e5aa0ef1"), PermissionId = Guid.Parse("ffe00ecd-e320-4a9d-84d7-2d3b2d16aa7b"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("0a918af0-de6e-4571-9d10-2b9e400731c3"), PermissionId = Guid.Parse("f6042a14-5907-4a6e-9417-0519cc422160"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("14f7831d-6d13-40a3-bedd-ca797cc72ed8"), PermissionId = Guid.Parse("ba75c802-413c-4209-abb5-d92fe883061c"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("1714b098-4d82-40b7-b7f8-a05a3b1ea5f4"), PermissionId = Guid.Parse("dc508983-5917-4752-8ccc-1c6674234417"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("19a5e887-6a1c-4e55-8db3-44b1bad09ece"), PermissionId = Guid.Parse("717a6cae-0844-4666-9621-c7082a8b9539"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("19f52fb7-f8df-4511-aa3c-47f1ec0b0b37"), PermissionId = Guid.Parse("8682fd93-c365-48f6-a363-720fd272a589"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("1d9a1b5b-7a4b-4058-8562-ac2aa0d36c3d"), PermissionId = Guid.Parse("d274575a-c4f2-4d0a-ab6a-c634fabf9c15"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("233ebd97-5c9f-47d5-96cd-4526164769c0"), PermissionId = Guid.Parse("161ab07a-92d0-422e-a7df-20e69238dad7"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("288bd58c-f8c3-458c-83b1-a73a81ef86cb"), PermissionId = Guid.Parse("24395707-0c33-42fe-bc05-39bd9b5e0485"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("2e231060-7f8a-4019-a266-87dc2beb3467"), PermissionId = Guid.Parse("929d0a6d-6b2d-4391-aa79-c4859b9cfa57"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("30dfc7f2-1db9-4642-bcdd-675016360c43"), PermissionId = Guid.Parse("bbb2b3dc-b3a5-4ce4-811c-7750cba00c59"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("320a73ad-f473-468f-afd7-d76d664b96a1"), PermissionId = Guid.Parse("0fe9b79f-8bf5-4742-8284-5414494988b0"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("38594a70-4af7-4c54-840e-fe424706711a"), PermissionId = Guid.Parse("2dd17f8f-6e80-4e60-919d-e304b90d0f46"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("39496f49-6060-424e-8d65-65e4b026a64d"), PermissionId = Guid.Parse("588ec542-ed55-4e66-9215-1c9216c5c914"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("5661b5c1-642a-4119-8f65-7554ee45d7e0"), PermissionId = Guid.Parse("3bd9aa44-f431-43a6-8b0a-ca99b77d100c"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("59a69444-5471-4992-9e7b-0bad2ec6d61a"), PermissionId = Guid.Parse("54b2a2a2-eccb-4241-8ece-d4e5a9beebaa"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("63d9665b-0ce0-42e5-87be-9980952b5169"), PermissionId = Guid.Parse("b3deaccb-bd01-4cd6-a543-9a001a93101c"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("67127b93-5e66-4da4-a23d-56b0f9939a5c"), PermissionId = Guid.Parse("2ad66724-24d7-4a86-b512-7cf5a4c4bfc3"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("7414d9f5-bd59-4d7c-846c-0e716bc7b569"), PermissionId = Guid.Parse("0678fae5-e577-4fd5-a759-ae3fb0fd9d6b"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("7f3d63ad-6b05-408c-bced-a2fd9e00f660"), PermissionId = Guid.Parse("75cf41d2-ca8f-4cb0-a37c-e3b34ddcb8c9"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("863cdc15-04ae-413d-b164-3bc76e52e429"), PermissionId = Guid.Parse("05958f1c-844a-43e9-9bcb-6667dad75670"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("8d61443f-5684-49ca-9dc8-687a403fedfe"), PermissionId = Guid.Parse("9054c555-4a30-495b-95d4-fff561ce11c6"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("90e45009-9f72-4246-a736-5d7685726197"), PermissionId = Guid.Parse("cbd3a20b-a12a-437d-b130-ef77cb174edf"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("998d41a1-4cef-4d68-b905-6a9ab14860c3"), PermissionId = Guid.Parse("8cbaaf22-3f25-4e50-b4b9-cc5f4a78ba6c"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("9b473cda-5787-48e1-870a-539a83b61029"), PermissionId = Guid.Parse("2f6a2460-7e0c-4677-a9a7-0c90ac88e2c7"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("a6f36ab9-4d51-48c1-9c14-109608a6a221"), PermissionId = Guid.Parse("503fc79e-3f52-435b-9222-254c8c1fc738"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("a71c917c-d48c-4236-a816-83350a9c25ee"), PermissionId = Guid.Parse("5bada406-7bf0-41e7-8f6c-52f65760181c"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("aa55ac93-e119-4aaa-b1f7-ed8af687825c"), PermissionId = Guid.Parse("c7f65971-5dcf-45e8-b146-3df6a710df2c"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("aa830101-9350-4adf-8e06-7ba1c9c63588"), PermissionId = Guid.Parse("410edf32-53fb-4242-9ca1-009ae499fcca"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("afdc6758-94fb-4312-8012-5bb5a0fe17bf"), PermissionId = Guid.Parse("0aaa962a-8d64-4515-9659-63e37f98c8ca"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("c222f126-ab7e-4bcd-a379-86ca562bd505"), PermissionId = Guid.Parse("1f52010f-c57c-4031-a666-4ad9c4076404"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("c35c989d-fba8-4a49-a570-369c2e7690b4"), PermissionId = Guid.Parse("4f7c081e-b834-4fed-acfb-10d54e8c8f11"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("c588cfb0-8fcb-4808-a310-3d56a8f226a8"), PermissionId = Guid.Parse("ee46d590-2457-4b01-95f1-3af291450552"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("d4e16d02-e46d-432a-b7fd-852703bc2b99"), PermissionId = Guid.Parse("54e3c968-e8d4-4b43-87d6-6351076e0093"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("db07e1eb-b6e2-4be8-8982-7b92857bb4e9"), PermissionId = Guid.Parse("348f5ae9-8ee7-40e1-bd13-0166e437ed1b"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("dc86b276-a3e3-4db7-b41c-f91479691cbc"), PermissionId = Guid.Parse("3fb76b0e-bcf6-45a0-a141-42873cff242c"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("dfc3a9ac-79e9-47c1-bb64-93a5b38efa39"), PermissionId = Guid.Parse("6a088364-cfa7-4e7c-8a31-17cddc9f1370"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("e2bfaaad-62c7-4a93-a801-d1d619872f91"), PermissionId = Guid.Parse("90d0aaaf-793c-4cde-89ea-706cdd0c1a6d"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("e4afa176-d44e-4b9d-8af6-77fa958814e7"), PermissionId = Guid.Parse("0a1f874b-af1c-4b3f-8d3e-2714eb2a6ca4"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("ebf94ba8-1187-4034-b1d8-deb0eb1b20e8"), PermissionId = Guid.Parse("72d1cb2c-30b0-4b6c-a9cd-d471940f7b93"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("f31c456f-868c-464f-aabc-92c07da30dad"), PermissionId = Guid.Parse("489facd4-0546-4e91-9d2d-26afc5e60080"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("fcb5d0c4-4bc9-4a92-8f40-b0a767922b71"), PermissionId = Guid.Parse("19f3b0e7-cc0b-44ba-ad7f-3ad17bcc9949"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("fdbef808-0497-4340-b11c-e5847b48fad3"), PermissionId = Guid.Parse("a4f2229d-cd70-4c4f-a0fa-39e2f9e4a639"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("315DADE7-A364-4729-ADA3-BCF99CE44A57"), PermissionId = Guid.Parse("96F97762-8B1E-46D8-8450-F52E85C2C2AC"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("57DEC3C3-5278-4CDE-BCB3-804E1DB105A1"), PermissionId = Guid.Parse("95A80530-1B8A-4A6B-9C88-D0F57AD03FCB"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") },
            new TemporalPermission { Id = Guid.Parse("B1BC8599-3DBE-46B1-8CE8-24F42980FE2E"), PermissionId = Guid.Parse("2A02728C-4408-4628-84BF-3B9650DF5705"), RoleId = Guid.Parse("26c52004-d441-48d8-8e00-e2cea7e1d55a") }
        };

        modelBuilder.Entity<Permission>().HasData(permissions);

        modelBuilder.Entity<User>().HasData(
            new User 
            { 
                Id = Guid.Parse("672a5cb2-73fb-4f4c-8764-a6c104a3062d"),
                Username = "SuperAdminDev",
                Password = "dCrinPZBjSOiUEfsVO0nGg==",
                RoleId = Guid.Parse("26C52004-D441-48D8-8E00-E2CEA7E1D55A"),
                FirstName = "Super",
                LastName = "Admin",
                Email = "SuperAdmin@dev.com",
                ConfigurationId = Guid.Parse("ed187966-ffc8-4897-becc-619cfe584445"),
                LeadId = null,
                IsMale = true,
            }
        );

        modelBuilder.Entity<TemporalPermission>().HasData(temporalPermissions);
    }
}

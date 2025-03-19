using Daily.Planner.with.God.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Daily.Planner.with.God.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<ColorPalett> ColorPaletts { get; set; }
        public DbSet<Domain.Entities.Type> Types { get; set; }
        public DbSet<Ads> Ads { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Agenda> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                .WithMany()
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

            base.OnModelCreating(modelBuilder);
        }
    }

}

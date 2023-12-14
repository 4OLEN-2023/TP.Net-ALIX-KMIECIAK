using Microsoft.EntityFrameworkCore;
using MyVideoGames.DataContext.EntityTypesConfiguration;
using MyVideoGames.Model;  

namespace MyVideoGames.DataContext
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GameEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PlatformentityTypeConfiguration());
            
            SeedDatabase(modelBuilder);
        }

        public DbSet<Game>? Games { get; set; }
        public DbSet<Platform>? Platforms { get; set; }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                .HasData(
                    new Platform { Id = 1, Name = "Xbox One", },
                    new Platform { Id = 2, Name = "Playstation 5", },
                    new Platform { Id = 3, Name = "PC", }
                );

            modelBuilder.Entity<Game>()
                .HasData(
                    new Game { Id = 1, Name = "GTA V", Description = "", Slug="", PlayTime = 105, Rating = 5, RatingTop = 5, ReleaseDate= DateTime.Now, PlatformId=1 }
                );
        }
    }
    
    
}
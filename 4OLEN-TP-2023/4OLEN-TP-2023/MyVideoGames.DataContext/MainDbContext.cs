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
        }

        public DbSet<Game>? Games { get; set; }
        public DbSet<Platform>? Platforms { get; set; }

    
    }
}
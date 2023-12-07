using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVideoGames.Model;

namespace MyVideoGames.DataContext.EntityTypesConfiguration
{
    public class PlatformentityTypeConfiguration : IEntityTypeConfiguration<Platform>
    {
        public void Configure(EntityTypeBuilder<Platform> builder)
        {
            builder.HasKey(item => item.Id);
        }
    }
}
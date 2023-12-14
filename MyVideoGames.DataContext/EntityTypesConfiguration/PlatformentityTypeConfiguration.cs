using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyVideoGames.Model;

namespace MyVideoGames.DataContext.EntityTypesConfiguration;

public class PlatformentityTypeConfiguration : IEntityTypeConfiguration<Platform>
{
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(item => item.Id);
        builder.HasIndex(item => item.Name).IsUnique();

        builder.HasMany(item => item.RelatedGames);
    }
}
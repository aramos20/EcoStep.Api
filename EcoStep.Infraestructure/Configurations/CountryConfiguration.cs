using EcoStep.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoStep.Infrastructure.Configurations;

public class CountryConfiguration : EntityTypeBaseConfiguration<Country>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Province)
            .WithOne(x => x.Country);
    }
    protected override void ConfigurateTableName(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<Country> builder)
    {
        builder.Property(x => x.CountryName)
            .IsRequired()
            .HasMaxLength(100);
    }

    protected override void SeedData(EntityTypeBuilder<Country> builder)
    {
        builder.HasData(
            new Country
            {
                Id = 1,
                CountryName = "Spain",
                CreatedAt = null,
                UpdatedAt = null,
                IsDeleted = false
            }
        );
    }
}
using EcoStep.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoStep.Infrastructure.Configurations;

public class GenderConfiguration : EntityTypeBaseConfiguration<Gender>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<Gender> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.User)
            .WithOne(x => x.Gender).HasForeignKey(x => x.GenderId);
    }
    protected override void ConfigurateTableName(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable("Genders");
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<Gender> builder)
    {
        builder.HasData(
            new Gender
            {
                Id = 1,
                GenderName = "Male",
                CreatedAt = null,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Gender
            {
                Id = 2,
                GenderName = "Female",
                CreatedAt = null,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Gender
            {
                Id = 3,
                GenderName = "Non-binary",
                CreatedAt = null,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Gender
            {
                Id = 4,
                GenderName = "Gender fluid",
                CreatedAt = null,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Gender
            {
                Id = 5,
                GenderName = "Agender",
                CreatedAt = null,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Gender
            {
                Id = 6,
                GenderName = "Bigender",
                CreatedAt = null,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Gender
            {
                Id = 7,
                GenderName = "Demiboy",
                CreatedAt = null,
                UpdatedAt = null,
                IsDeleted = false
            },
            new Gender
            {
                Id = 8,
                GenderName = "DemiGirl",
                CreatedAt = null,
                UpdatedAt = null,
                IsDeleted = false
            }
        );
    }


}
using EcoStep.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoStep.Infrastructure.Configurations;

public class ImageConfiguration : EntityTypeBaseConfiguration<Image>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.User)
            .WithOne(x => x.Image)
            .HasForeignKey<Image>(x => x.UserId);
    }
    protected override void ConfigurateTableName(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images");
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<Image> builder)
    {
        builder.Property(x => x.ImageUrl)
            .IsRequired()
            .HasMaxLength(100);
    }


}
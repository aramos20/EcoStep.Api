using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EcoStep.Domain.Models;
namespace EcoStep.Infrastructure.Configurations;
public class UserConfiguration : EntityTypeBaseConfiguration<User>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Country)
            .WithMany(x => x.User)
            .HasForeignKey(x => x.CountryId);

        builder.HasOne(x => x.Province)
            .WithMany(x => x.User)
            .HasForeignKey(x => x.ProvinceId);

        builder.HasOne(x => x.Gender)
            .WithMany(x => x.User)
            .HasForeignKey(x => x.GenderId);

        builder.HasOne(x => x.Image)
            .WithOne(x => x.User)
            .HasForeignKey<Image>(x => x.UserId);
    }
    protected override void ConfigurateProperties(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(200);

    }
    protected override void ConfigurateTableName(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
    }

}
using EcoStep.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcoStep.Infrastructure.Configurations;

public class ProvinceConfiguration : EntityTypeBaseConfiguration<Province>
{
    protected override void ConfigurateConstraints(EntityTypeBuilder<Province> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Country)
            .WithMany(x => x.Province)
            .HasForeignKey(x => x.CountryId);
    }
    protected override void ConfigurateTableName(EntityTypeBuilder<Province> builder)
    {
        builder.ToTable("Provinces");
    }

    protected override void ConfigurateProperties(EntityTypeBuilder<Province> builder)
    {
        builder.Property(x => x.ProvinceName)
            .IsRequired()
            .HasMaxLength(100);
    }

    protected override void SeedData(EntityTypeBuilder<Province> builder)
    {
        builder.HasData(
     new Province { Id = 1, ProvinceName = "Álava", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 2, ProvinceName = "Albacete", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 3, ProvinceName = "Alicante", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 4, ProvinceName = "Almería", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 5, ProvinceName = "Asturias", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 6, ProvinceName = "Ávila", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 7, ProvinceName = "Badajoz", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 8, ProvinceName = "Baleares", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 9, ProvinceName = "Barcelona", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 10, ProvinceName = "Burgos", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 11, ProvinceName = "Cáceres", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 12, ProvinceName = "Cádiz", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 13, ProvinceName = "Cantabria", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 14, ProvinceName = "Castellón", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 15, ProvinceName = "Ceuta", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 16, ProvinceName = "Ciudad Real", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 17, ProvinceName = "Córdoba", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 18, ProvinceName = "Cuenca", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 19, ProvinceName = "Girona", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 20, ProvinceName = "Granada", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 21, ProvinceName = "Guadalajara", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 22, ProvinceName = "Guipúzcoa", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 23, ProvinceName = "Huelva", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 24, ProvinceName = "Huesca", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 25, ProvinceName = "Jaén", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 26, ProvinceName = "La Coruña", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 27, ProvinceName = "La Rioja", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 28, ProvinceName = "Las Palmas", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 29, ProvinceName = "León", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 30, ProvinceName = "Lleida", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 31, ProvinceName = "Lugo", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 32, ProvinceName = "Madrid", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 33, ProvinceName = "Málaga", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 34, ProvinceName = "Melilla", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 35, ProvinceName = "Murcia", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 36, ProvinceName = "Navarra", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 37, ProvinceName = "Ourense", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 38, ProvinceName = "Palencia", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 39, ProvinceName = "Pontevedra", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 40, ProvinceName = "Salamanca", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 41, ProvinceName = "Santa Cruz de Tenerife", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 42, ProvinceName = "Segovia", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 43, ProvinceName = "Sevilla", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 44, ProvinceName = "Soria", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 45, ProvinceName = "Tarragona", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 46, ProvinceName = "Teruel", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 47, ProvinceName = "Toledo", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 48, ProvinceName = "Valencia", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 49, ProvinceName = "Valladolid", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 50, ProvinceName = "Vizcaya", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 51, ProvinceName = "Zamora", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false },
     new Province { Id = 52, ProvinceName = "Zaragoza", CountryId = 1, CreatedAt = null, UpdatedAt = null, IsDeleted = false }
 );

    }

}
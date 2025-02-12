using Animals.Core.Domain.Animals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace _5Layers.Animals.Persistence.EFCore.AnimalsDb.EntityTypesConfigurations;

internal class AnimalsTypeConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Age)
            .IsRequired();

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
        .IsRequired();

        builder
            .Metadata
            .FindNavigation(nameof(Animal.Owners))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(x => x.Owners)
            .WithOne(x => x.Animal)
            .HasForeignKey(x => x.AnimalId);
    }
}
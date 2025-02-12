using Animals.Core.Domain.Owners.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _5Layers.Animals.Persistence.EFCore.AnimalsDb.EntityTypesConfigurations;

public class OwnerEntityTypeConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasMaxLength(50);

        builder.Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Metadata
            .FindNavigation(nameof(Owner.Animals))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(x => x.Animals)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId);
    }
}
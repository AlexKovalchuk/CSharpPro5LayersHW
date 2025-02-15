using Animals.Core.Domain.Animals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _5Layers.Animals.Persistence.EFCore.AnimalsDb.EntityTypesConfigurations;

public class AnimalOwnerEntityTypeConfiguration : IEntityTypeConfiguration<AnimalOwner>
{
    public void Configure(EntityTypeBuilder<AnimalOwner> builder)
    {
        builder.HasKey(x => new { x.AnimalId, x.OwnerId });
    }
}
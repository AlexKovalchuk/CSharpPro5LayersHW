using Animals.Core.Domain.Animals.Models;
using Animals.Core.Domain.Owners.Models;
using Microsoft.EntityFrameworkCore;

namespace _5Layers.Animals.Persistence.EFCore.AnimalsDb;

public class AnimalsDbContext(DbContextOptions<AnimalsDbContext> options) : DbContext(options)
{
    public static string AnimalsDbSchema = "animals";

    public static string AnimalsMigrationHistory = "__AnimalsMigrationHistory";

    public DbSet<Animal> Animals { get; set; }

    public DbSet<Owner> Owners { get; set; }

    public DbSet<AnimalOwner> AnimalsOwners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // todo: do it only for local development
        optionsBuilder.LogTo(Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(AnimalsDbSchema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimalsDbContext).Assembly);
    }
}
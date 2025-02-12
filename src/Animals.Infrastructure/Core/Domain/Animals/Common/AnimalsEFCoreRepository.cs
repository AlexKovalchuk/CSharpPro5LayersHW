using _5Layers.Animals.Persistence.EFCore.AnimalsDb;
using Animals.Core.Domain.Animals.Common;
using Animals.Core.Domain.Animals.Models;
using Microsoft.EntityFrameworkCore;

namespace Animals.Infrastructure.Core.Domain.Animals.Common;

public class AnimalsEFCoreRepository(AnimalsDbContext dbContext) : IAnimalsRepository
{
    public async Task<Animal> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext
            .Animals
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidOperationException("Animal was not found");
    }

    public void Add(Animal animal)
    {
        dbContext.Add(animal);
    }

    public void Delete(Animal animal)
    {
        dbContext.Remove(animal);
    }
}
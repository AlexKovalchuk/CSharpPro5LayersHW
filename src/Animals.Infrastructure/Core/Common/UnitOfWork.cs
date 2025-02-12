using _5Layers.Animals.Persistence.EFCore.AnimalsDb;
using Animals.Core.Common;

namespace Animals.Infrastructure.Core.Common;

internal class UnitOfWork(AnimalsDbContext dbContext) : IUnitOfWork
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken);
    }
}
using Animals.Core.Domain.Animals.Models;

namespace Animals.Core.Domain.Animals.Common;

public interface IAnimalsRepository
{
    Task<Animal> GetById(Guid id, CancellationToken cancellationToken);

    // this method usually is not needed as EF Core tracks changes to entities. Will learn later.
    // Task Update(Animal animal);

    // for the love of whatever higher power you believe in, please don't use Task here.
    // Read the documentation of the EF Core for further reasoning 
    void Add(Animal animal);

    // for the love of whatever higher power you believe in, please don't use Task here.
    // Read the documentation of the EF Core for further reasoning
    void Delete(Animal animal);
}
using _5Layers.Animals.Persistence.EFCore.AnimalsDb;
using Animals.Application.Domain.Animals.Queries.GetAnimalDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Animals.Infrastructure.Application.Domain.Animals.Queries.GetAnimalDetails;

public class GetAnimalDetailsQueryHandler(AnimalsDbContext dbContext) : IRequestHandler<GetAnimalDetailsQuery, AnimalDetailsDto>
{
    public async Task<AnimalDetailsDto> Handle(
        GetAnimalDetailsQuery query, 
        CancellationToken cancellationToken)
    {
        var animal = await dbContext
                   .Animals
                   .AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken)
               ?? throw new ArgumentException($"Animal with id: {query.Id} was not found.", nameof(query.Id));

        return new AnimalDetailsDto(
            animal.Id,
            animal.Name,
            animal.Age,
            animal.Description);
    }
}
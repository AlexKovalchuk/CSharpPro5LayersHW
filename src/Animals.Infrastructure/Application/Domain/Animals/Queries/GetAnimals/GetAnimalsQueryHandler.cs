using _5Layers.Animals.Persistence.EFCore.AnimalsDb;
using Animals.Application.Common;
using Animals.Application.Domain.Animals.Queries.GetAnimals;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AnimalDto = Animals.Application.Domain.Animals.Queries.GetAnimals.AnimalDto;

namespace Animals.Infrastructure.Application.Domain.Animals.Queries.GetAnimals;

internal class GetAnimalsQueryHandler(AnimalsDbContext dbContext)
    : IRequestHandler<GetAnimalsQuery, PageResponse<AnimalDto[]>>
{
    public async Task<PageResponse<AnimalDto[]>> Handle(
        GetAnimalsQuery query,
        CancellationToken cancellationToken)
    {
        var sqlQuery = dbContext
            .Animals
            .AsNoTracking()
            .Include(x=>x.Owners);

        var skip = query.PageSize * (query.Page - 1);

        var count = sqlQuery.Count();

        var animals = await sqlQuery
            .OrderBy(a => a.Name)
            .Skip(skip)
            .Take(query.PageSize)
            .Select(x => new AnimalDto(
                x.Id,
                x.Name,
                x.Age,
                x.Owners.Select(o => new OwnerDto(o.Owner.FirstName, o.Owner.LastName)).ToArray()
            ))
            .ToArrayAsync(cancellationToken);

        return new PageResponse<AnimalDto[]>(count, animals);
    }
}
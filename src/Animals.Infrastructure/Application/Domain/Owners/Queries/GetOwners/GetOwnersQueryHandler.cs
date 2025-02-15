using _5Layers.Animals.Persistence.EFCore.AnimalsDb;
using Animals.Application.Common;
using Animals.Application.Domain.Owners.Queries.GetOwners;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Animals.Infrastructure.Application.Domain.Owners.Queries.GetOwners;

public class GetOwnersQueryHandler(AnimalsDbContext dbContext) : IRequestHandler<GetOwnersQuery, PageResponse<OwnerDto[]>>
{
    public async Task<PageResponse<OwnerDto[]>> Handle(
        GetOwnersQuery query, 
        CancellationToken cancellationToken)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);
        var sqlQuery =  dbContext.Owners;
        var total = await sqlQuery.CountAsync(cancellationToken);
        var skip = (query.Page - 1) * query.PageSize;
        var owners = await sqlQuery
            .Skip(skip)
            .Take(query.PageSize)
            .Select(x => new OwnerDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber
            })
            .ToArrayAsync(cancellationToken);

        await transaction.CommitAsync(cancellationToken);
        return new PageResponse<OwnerDto[]>(total, owners);
    }
}
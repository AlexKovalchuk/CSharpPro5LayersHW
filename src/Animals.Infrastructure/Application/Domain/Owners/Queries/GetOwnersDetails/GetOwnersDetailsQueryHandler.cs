 using _5Layers.Animals.Persistence.EFCore.AnimalsDb;
using Animals.Application.Domain.Owners.Queries.GetOwnersDetails;
using Animals.Core.Domain.Owners.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Animals.Infrastructure.Application.Domain.Owners.Queries.GetOwnersDetails
{
    internal class GetOwnersDetailsQueryHandler(AnimalsDbContext dbContext) : IRequestHandler<GetOwnersDetailsQuery, OwnerDetailsDto>
    {
        public async Task<OwnerDetailsDto> Handle(GetOwnersDetailsQuery query, CancellationToken cancellationToken)
        {
           /* var sqlQuery = await dbContext
                .Owners
                .Join(dbContext.AnimalsOwners, owner => owner.Id, animalOwner => animalOwner.OwnerId,
                    (owner, animalOwner) => new { owner, animalOwner })
                .Join(dbContext.Animals, joinResult => joinResult.animalOwner.AnimalId, animal => animal.Id,
                    (joinResult, animal) => new { Owner = joinResult.owner, Animal = animal })
                .Where(x => x.Owner.Id == query.Id)
                .ToArrayAsync(cancellationToken);*/

            var sqlQuery = await (
               from Owner in dbContext.Owners
               join animalOwner in dbContext.AnimalsOwners on Owner.Id equals animalOwner.OwnerId into animalOwners
               from animalOwner in animalOwners.DefaultIfEmpty()
               join animal in dbContext.Animals on animalOwner.AnimalId equals animal.Id into animals
               from animal in animals.DefaultIfEmpty()
               where Owner.Id == query.Id
               select new { Owner, Animal = animal }
               ).ToArrayAsync(cancellationToken);

            var owner = sqlQuery.FirstOrDefault().Owner ?? throw new ArgumentException("Not found!");

            var fullName = owner.MiddleName is null ?
                $"{owner.FirstName} {owner.LastName}" : $"{owner.FirstName} {owner.MiddleName} {owner.LastName}";

            var res = new OwnerDetailsDto()
            {
                Id = owner.Id,
                FullName = fullName,
                Email = owner.Email,
                PhoneNumber = owner.PhoneNumber,
                Animals = sqlQuery
                    .Where(x => x.Animal is not null)
                    .Select(x => new AnimalDto()
                {
                    Id = x.Animal.Id,
                    Name = x.Animal.Name,
                }).ToList()
            };
            return res;
        }
    }
}

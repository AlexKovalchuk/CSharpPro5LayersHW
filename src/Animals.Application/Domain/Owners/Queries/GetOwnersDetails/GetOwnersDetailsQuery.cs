using MediatR;

namespace Animals.Application.Domain.Owners.Queries.GetOwnersDetails;

public record GetOwnersDetailsQuery(Guid Id):IRequest<OwnerDetailsDto>;
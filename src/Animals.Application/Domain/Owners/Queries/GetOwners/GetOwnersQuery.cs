using Animals.Application.Common;
using MediatR;

namespace Animals.Application.Domain.Owners.Queries.GetOwners;

public record GetOwnersQuery(int Page, int PageSize) : IRequest<PageResponse<OwnerDto[]>>;
using Animals.Core.Domain.Owners.Models;

namespace Animals.Core.Domain.Owners.Common;

public interface IOwnersRepository
{
    Task<Owner> GetOwnerById(Guid ownerId, CancellationToken cancellationToken);
}
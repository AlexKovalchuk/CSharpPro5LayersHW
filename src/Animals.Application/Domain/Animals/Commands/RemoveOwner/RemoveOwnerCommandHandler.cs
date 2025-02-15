using Animals.Core.Common;
using Animals.Core.Domain.Animals.Common;
using Animals.Core.Domain.Owners.Common;
using MediatR;

namespace Animals.Application.Domain.Animals.Commands.RemoveOwner;

public class RemoveOwnerCommandHandler(
    IAnimalsRepository animalsRepository,
    IOwnersRepository ownersRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveOwnerCommand>
{
    public async Task Handle(RemoveOwnerCommand command, CancellationToken cancellationToken)
    {
        var animal = await animalsRepository.GetById(command.AnimalId, cancellationToken);
        var owner = await ownersRepository.GetById(command.OwnerId, cancellationToken);
        animal.RemoveOwner(owner);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
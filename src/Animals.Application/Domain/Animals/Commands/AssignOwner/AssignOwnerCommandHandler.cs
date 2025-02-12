using Animals.Core.Common;
using Animals.Core.Domain.Animals.Common;
using Animals.Core.Domain.Owners.Common;
using MediatR;

namespace Animals.Application.Domain.Animals.Commands.AssignOwner;

public class AssignOwnerCommandHandler(
    /*IAnimalsRepository animalsRepository,
    IOwnersRepository ownersRepository,
    IUnitOfWork unitOfWork*/) : IRequestHandler<AssignOwnerCommand>
{
    public async Task Handle(AssignOwnerCommand command, CancellationToken cancellationToken)
    {
       /* var animal = await animalsRepository.GetById(command.AnimalId, cancellationToken);
        var owner = await ownersRepository.GetOwnerById(command.OwnerId, cancellationToken);
        animal.AssignOwner(owner);
        await unitOfWork.SaveChangesAsync(cancellationToken);*/
    }
}
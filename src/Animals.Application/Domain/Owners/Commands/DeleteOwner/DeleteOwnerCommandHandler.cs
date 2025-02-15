using Animals.Core.Common;
using Animals.Core.Domain.Owners.Common;
using MediatR;

namespace Animals.Application.Domain.Owners.Commands.DeleteOwner
{
    internal class DeleteOwnerCommandHandler(
        IOwnersRepository ownersRepository, 
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteOwnerCommand>
    {
        public async Task Handle(DeleteOwnerCommand command, CancellationToken cancellationToken)
        {
            var owner = await ownersRepository.GetByIdOrDefault(command.Id, cancellationToken);

            if(owner is not null)
            {
                ownersRepository.Delete(owner);
                await unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

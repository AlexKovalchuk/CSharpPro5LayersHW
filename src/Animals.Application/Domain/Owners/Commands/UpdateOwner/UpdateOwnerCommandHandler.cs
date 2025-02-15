using Animals.Core.Common;
using Animals.Core.Domain.Owners.Common;
using Animals.Core.Domain.Owners.Data;
using MediatR;

namespace Animals.Application.Domain.Owners.Commands.UpdateOwner
{
    internal class UpdateOwnerCommandHandler(
        IOwnersRepository ownersRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdateOwnerCommand>
    {
        public async Task Handle(UpdateOwnerCommand command, CancellationToken cancellationToken)
        {
            var owner = await ownersRepository.GetById(command.Id, cancellationToken);
            var data = new UpdateOwnerData(
                    command.FirstName,
                    command.LastName,
                    command.MiddleName,
                    command.Email,
                    command.PhoneNumber);

            owner.Update(data);
            
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}

using Animals.Core.Common;
using Animals.Core.Domain.Owners.Common;
using Animals.Core.Domain.Owners.Data;
using Animals.Core.Domain.Owners.Models;
using MediatR;

namespace Animals.Application.Domain.Owners.Commands.CreateOwner
{
    internal class CreateOwnerCommandHandler(
        IOwnersRepository ownersRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateOwnerCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOwnerCommand command, CancellationToken cancellationToken)
        {
            var data = new CreateOwnerData(
                command.FirstName,
                command.LastName,
                command.MiddleName,
                command.Email,
                command.PhoneNumber);

            var owner = Owner.Create(data);

            ownersRepository.Add(owner);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return owner.Id;
        }
    }
}

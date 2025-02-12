using Animals.Core.Common;
using Animals.Core.Domain.Animals.Common;
using Animals.Core.Domain.Animals.Data;
using MediatR;

namespace Animals.Application.Domain.Animals.Commands.UpdateAnimal;

internal class UpdateAnimalCommandHandler(
    IAnimalsRepository animalsRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateAnimalCommand>
{
    public async Task Handle(
        UpdateAnimalCommand command,
        CancellationToken cancellationToken)
    {
        var animal = await animalsRepository.GetById(command.Id, cancellationToken);
        var data = new UpdateAnimalData(command.Name, command.Age, command.Description);
        animal.Update(data);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
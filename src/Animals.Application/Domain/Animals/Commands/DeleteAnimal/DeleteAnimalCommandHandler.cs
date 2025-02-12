using Animals.Core.Common;
using Animals.Core.Domain.Animals.Common;
using MediatR;

namespace Animals.Application.Domain.Animals.Commands.DeleteAnimal;

public class DeleteAnimalCommandHandler(
    IAnimalsRepository animalsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteAnimalCommand>
{
    public async Task Handle(
        DeleteAnimalCommand command,
        CancellationToken cancellationToken)
    {
        var animal = await animalsRepository.GetById(command.Id, cancellationToken);
        animalsRepository.Delete(animal);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
using Animals.Core.Common;
using Animals.Core.Domain.Animals.Common;
using Animals.Core.Domain.Animals.Data;
using Animals.Core.Domain.Animals.Models;
using MediatR;

namespace Animals.Application.Domain.Animals.Commands.CreateAnimal;

internal class CreateAnimalCommandHandler(
    IAnimalsRepository animalsRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateAnimalCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateAnimalCommand command, 
        CancellationToken cancellationToken)
    {
        var data = new CreateAnimalData(command.Name, command.Age, command.Description);

        var animal = Animal.Create(data);

        animalsRepository.Add(animal);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return animal.Id;
    }
}
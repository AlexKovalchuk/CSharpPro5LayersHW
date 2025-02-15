using MediatR;

namespace Animals.Application.Domain.Animals.Commands.RemoveOwner;

public record RemoveOwnerCommand(Guid AnimalId, Guid OwnerId) : IRequest;
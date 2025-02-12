using MediatR;

namespace Animals.Application.Domain.Animals.Commands.AssignOwner;

public record AssignOwnerCommand(Guid AnimalId, Guid OwnerId) : IRequest;
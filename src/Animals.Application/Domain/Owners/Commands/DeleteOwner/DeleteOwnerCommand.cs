using MediatR;

namespace Animals.Application.Domain.Owners.Commands.DeleteOwner;

public record DeleteOwnerCommand(Guid Id) : IRequest;
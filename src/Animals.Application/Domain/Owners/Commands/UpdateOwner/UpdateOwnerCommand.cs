using MediatR;

namespace Animals.Application.Domain.Owners.Commands.UpdateOwner;

public record UpdateOwnerCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber) : IRequest;
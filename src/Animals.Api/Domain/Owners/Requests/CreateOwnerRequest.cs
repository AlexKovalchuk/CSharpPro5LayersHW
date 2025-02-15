namespace Animals.Api.Domain.Owners.Requests;

public record CreateOwnerRequest(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber);
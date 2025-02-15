namespace Animals.Api.Domain.Owners.Requests;

public record UpdateOwnerRequest(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber);
namespace Animals.Core.Domain.Owners.Data;

public record UpdateOwnerData(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber);
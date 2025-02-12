namespace Animals.Core.Domain.Owners.Data;

public record CreateOwnerData(
    string FirstName,
    string LastName,
    string? MiddleName,
    string Email,
    string PhoneNumber);
namespace Animals.Application.Domain.Owners.Queries.GetOwners;

public record OwnerDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }

    public string LastName { get; init; }

    public string? MiddleName { get; set; }

    public string Email { get; init; }

    public string PhoneNumber { get; init; }
}
namespace Animals.Application.Domain.Owners.Queries.GetOwnersDetails;

public record OwnerDetailsDto
{
    public Guid Id { get; init; }

    public string FullName { get; init; }

    public string Email { get; init; }

    public string PhoneNumber { get; init; }

    public List<AnimalDto> Animals { get; init; }
}
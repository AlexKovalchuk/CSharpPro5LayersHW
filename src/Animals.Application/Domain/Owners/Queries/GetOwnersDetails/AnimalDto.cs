namespace Animals.Application.Domain.Owners.Queries.GetOwnersDetails;

public record AnimalDto
{
    public Guid Id { get; init; }

    public string Name { get; init; }
}
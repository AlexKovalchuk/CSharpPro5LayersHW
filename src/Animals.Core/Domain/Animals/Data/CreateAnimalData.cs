namespace Animals.Core.Domain.Animals.Data;

public record CreateAnimalData(
    string Name,
    int Age,
    string Description);
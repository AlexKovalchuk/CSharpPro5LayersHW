namespace Animals.Core.Domain.Animals.Data;

public record UpdateAnimalData(
    string Name,
    int Age,
    string Description);
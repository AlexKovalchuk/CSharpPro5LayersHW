using System.Runtime.CompilerServices;
using System.Xml.Schema;
using Animals.Core.Common;
using Animals.Core.Domain.Animals.Data;
using Animals.Core.Domain.Owners.Models;


// allow internal access for Animals.Infrastructure project
[assembly: InternalsVisibleTo("Animals.Infrastructure")]

namespace Animals.Core.Domain.Animals.Models;

public class Animal : IAggregateRoot
{
    private readonly List<AnimalOwner> _owners = new();

    // please leave it as is for Entity Framework. It needs it for materialization of entities.
    // read about it here: https://docs.microsoft.com/en-us/ef/core/modeling/constructors
    private Animal()
    {
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyCollection<AnimalOwner> Owners => _owners.AsReadOnly();

    internal Animal(
        Guid id,
        string name,
        int age,
        string description)
    {
        Id = id;
        Name = name;
        Age = age;
        Description = description;
    }

    public void Update(UpdateAnimalData data)
    {
        Name = data.Name;
        Age = data.Age;
        Description = data.Description;
    }

    public static Animal Create(CreateAnimalData data)
    {
        return new Animal(
            Guid.NewGuid(),
            data.Name,
            data.Age,
            data.Description);
    }

    public void AssignOwner(Owner owner)
    {
        if (_owners.All(x => x.OwnerId != owner.Id))
        {
            var ao = AnimalOwner.Create(Id, owner.Id);
            _owners.Add(ao);
        }
    }

    public void AssignOwner(Owner[] owners)
    {
        var animalOwners = owners
            .Where( o => _owners.All(x => x.OwnerId != o.Id))
            .Select(owner => AnimalOwner.Create(Id, owner.Id));

        _owners.AddRange(animalOwners);
    }
}
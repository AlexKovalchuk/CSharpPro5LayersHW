using Animals.Core.Domain.Animals.Models;
using Animals.Core.Domain.Owners.Data;

namespace Animals.Core.Domain.Owners.Models;

public class Owner
{
    private List<AnimalOwner> _animals = new();

    private Owner(){}

    private Owner(
        Guid id,
        string firstName, 
        string lastName,
        string? middleName,
        string email, 
        string phoneNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public Guid Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string? MiddleName { get; private set; }

    public string Email { get; private set; }

    public string PhoneNumber { get; private set; }

    public IReadOnlyCollection<AnimalOwner> Animals => _animals.AsReadOnly();

    public static Owner Create(CreateOwnerData data)
    {
        return new Owner(
            Guid.NewGuid(),
            data.FirstName,
            data.LastName,
            data.MiddleName,
            data.Email,
            data.PhoneNumber
        );
    }
}
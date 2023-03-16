using PetShelter.Domain;

namespace PetShelter.Api.Resources.Extensions;

public static class PersonExtensions
{
    public static Domain.Person AsDomainModel(this Person person)
    {
        var domainModel = new Domain.Person( person.IdNumber,person.Name);
        domainModel.Name = person.Name;
        domainModel.IdNumber = person.IdNumber;
        domainModel.DateOfBirth=person.DateOfBirth;
        return domainModel;
    }

    public static Person AsResource(this Domain.Person person)
    {
        return new Person
        {
            DateOfBirth = person.DateOfBirth,
            IdNumber = person.IdNumber,
            Name = person.Name,
        };
    }
}
namespace PetShelter.Domain
{
    public class Person:INamedEntity
    {
        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string IdNumber { get; set; }

        public Person(string idNumber, string name, DateTime? dateOfBirth = null)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            IdNumber = idNumber;
        }
    }
}

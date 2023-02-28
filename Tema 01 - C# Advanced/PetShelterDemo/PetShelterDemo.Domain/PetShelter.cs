using PetShelterDemo.DAL;

namespace PetShelterDemo.Domain;

public class PetShelter
{
    private readonly IRegistry<Pet> petRegistry;
    private readonly IRegistry<Person> donorRegistry;
    public List<Fundraiser> Fundraisers { get; set; }=new List<Fundraiser>();
    private Donations donations;

    public PetShelter()
    {
        donorRegistry = new Registry<Person>(new Database());
        petRegistry = new Registry<Pet>(new Database());
        donations=new Donations();
    }

    public void RegisterPet(Pet pet)
    {
        petRegistry.Register(pet);
    }

    public void RegisterFundraiser(Fundraiser fundraiser)
    {
        Fundraisers.Add(fundraiser);
    }

    public IReadOnlyList<Pet> GetAllPets()
    {
        return petRegistry.GetAll().Result; // Actually blocks thread until the result is available.
    }

    public Pet GetByName(string name)
    {
        return petRegistry.GetByName(name).Result;
    }

    public void Donate(Person donor, int amount)
    {
     
        donorRegistry.Register(donor);
        Console.WriteLine("Choose your currency");
        var tipMoneda = Console.ReadLine();
        //donations += amount;
        if(tipMoneda.Equals("EUR")) {
            donations.EUR += amount;
        }
        else if (tipMoneda.Equals("RON"))
        {
                donations.RON += amount;
        }
        
        else if (tipMoneda.Equals("DOLLAR"))
            {
                donations.DOLLAR += amount;
            }
        else
        {
            Console.WriteLine("You currency isn't correct");
        }
    }

    public int GetTotalDonationsInRON()
    {
        return (int)donations.RON;
    }

    public int GetTotalDonationsInEUR()
    {
        return (int)donations.EUR;
    }

    public int GetTotalDonationsInDOLLAR()
    {
        return (int)donations.DOLLAR;
    }



    public IReadOnlyList<Person> GetAllDonors()
    {
        return donorRegistry.GetAll().Result;
    }
}
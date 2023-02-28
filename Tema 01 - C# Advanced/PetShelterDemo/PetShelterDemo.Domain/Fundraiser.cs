namespace PetShelterDemo.Domain
{
    public class Fundraiser
    {
        public string Title { get; }
        public string Description { get; }
        public int DonationTarget { get; }
        public int TotalDonations { get; }
        public List<Person> Donors { get; set; }



        public Fundraiser(string title, string description)
        {
            Title = title; 
            Description = description;
            Donors = new List<Person>();
        }

    }
}


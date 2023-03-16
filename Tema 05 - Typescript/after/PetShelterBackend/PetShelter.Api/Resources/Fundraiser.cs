using PetShelter.DataAccessLayer.Models;
using PetShelter.Domain;

namespace PetShelter.Api.Resources
{
    public class Fundraiser
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DonationTarget { get; set; }
        public decimal TotalDonations { get; set; }
        public List<Person> Donors { get; set; }
        public ICollection<Donation> Donations { get; set; }
        public DateTime DueDate { get; internal set; }
        public DateTime CreationTime { get; internal set; }
        public int Id { get; internal set; }
        public FundraiserStatus Status { get; internal set; }
        public Person Owner { get; set; }
    }
}

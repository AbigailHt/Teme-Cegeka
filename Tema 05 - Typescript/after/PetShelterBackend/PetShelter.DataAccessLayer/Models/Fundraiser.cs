namespace PetShelter.DataAccessLayer.Models
{
    public class Fundraiser : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DonationTarget { get; set; }
        public Person Owner { get; set; }
        public int? OwnerId { get; set; }
        public ICollection<Person> Donors { get; set; }
        public ICollection<Donation> Donations { get; set; }
        public FundraiserStatus Status { get; set; }
        public DateTime CreationTime { get; set; }

        public decimal RaisedAmount
        {
            get; set;
        }

        public DateTime DueDate { get; set; }
    }

}

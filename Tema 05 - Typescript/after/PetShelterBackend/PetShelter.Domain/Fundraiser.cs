using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain
{
    public class Fundraiser:FundraiserInfo,INamedEntity
    {
        public string Name { get; set; }
        public decimal DonationTarget { get; set; }
        public Person Owner { get; set; }
        public DateTime DueDate { get; set; }

        public Fundraiser(string name,decimal goalValue,Person owner, DateTime dueDate) {
            Name= name;
            DonationTarget = goalValue;
            Owner= owner;
            DueDate=dueDate;
        }
    }
}

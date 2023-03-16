using PetShelter.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain
{
    public class FundraiserInfo
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public FundraiserStatus Status { get; set; }
        public DateTime CreationTime { get; set; }
        public decimal RaisedAmount { get; set; }
        public List<Person> Donors { get; set; }=new List<Person>();
        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
    }
}

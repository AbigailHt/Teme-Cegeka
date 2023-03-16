using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.DataAccessLayer.Models
{
    public class Fundraiser : IEntity
    {
        public int Id { get; set; }
        public string Title { get; }
        public string Description { get; set; }
        public ICollection<Donation> Donations { get; set; }
    }
}

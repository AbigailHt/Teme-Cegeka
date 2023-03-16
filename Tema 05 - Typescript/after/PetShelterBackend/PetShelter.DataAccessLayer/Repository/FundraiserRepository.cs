using PetShelter.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.DataAccessLayer.Repository
{
    public class FundraiserRepository : BaseRepository<Fundraiser>, IFundraiserRepository
    {
        public FundraiserRepository(PetShelterContext context) : base(context)
        {
        }

        public decimal CalculateRaisedAmount(int fundraiserId)
        {
            var fundraiser = _context.Set<Fundraiser>().Find(fundraiserId);
            if (fundraiser == null)
            {
                throw new ArgumentException($"Fundraiser with ID {fundraiserId} not found");
            }
            return fundraiser.RaisedAmount;
        }

        public Fundraiser GetFundraiserByName(string name)
        {
            var fundraiser = _context.Set<Fundraiser>().Find(name);
            if (fundraiser == null)
            {
                throw new ArgumentException($"Fundraiser with ID {name} not found");
            }
            return fundraiser;
        }
    }
}

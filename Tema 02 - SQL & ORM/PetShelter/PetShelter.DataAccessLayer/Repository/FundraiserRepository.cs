using Microsoft.EntityFrameworkCore;
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
        public FundraiserRepository(PetShelterContext context) : base(context){}

        public Task<decimal> CurrentRaisedAmount() => _context.Fundraisers.SelectMany(i => i.Donations).SumAsync(sum => sum.Amount);
    }
}

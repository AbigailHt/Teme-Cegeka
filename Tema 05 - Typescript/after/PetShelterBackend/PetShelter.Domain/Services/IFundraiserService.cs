using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Services
{
    public interface IFundraiserService
    {
        Task CreateFundraiserAsync(string name, decimal goalValue, Person owner, DateTime dueDate);
        Task<Fundraiser> GetFundraiserAsync(int fundraiserId);
        Task<IReadOnlyList<Fundraiser>> GetAllFundraisersAsync();
        Task DonateToFundraiserAsync(int fundraiserId, Person donor, int donationValue);
        Task DeleteFundraiserAsync(int fundraiserId);
    }
}

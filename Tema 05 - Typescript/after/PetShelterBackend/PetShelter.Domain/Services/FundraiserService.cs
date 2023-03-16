using Microsoft.VisualBasic;
using PetShelter.DataAccessLayer.Models;
using PetShelter.DataAccessLayer.Repository;
using PetShelter.Domain.Extensions.DataAccess;
using PetShelter.Domain.Extensions.DomainModel;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Services
{
    public class FundraiserService: IFundraiserService
    {
        private readonly IFundraiserRepository _fundraiserRepository;
        private readonly IPersonRepository _personRepository;

        public FundraiserService(IFundraiserRepository fundraiserRepository, IPersonRepository personRepository)
        {
            _fundraiserRepository = fundraiserRepository;
            _personRepository = personRepository;
        }

        public async Task CreateFundraiserAsync(string name, decimal GoalValue, Person owner, DateTime dueDate)
        {
            var fundraiser= _fundraiserRepository.GetFundraiserByName(name);
            var ownerRepo = await _personRepository.GetOrAddPersonAsync(owner.FromDomainModel());
            if (fundraiser == null)
            {
                throw new ArgumentException();
            }
            fundraiser.Title = name;
            fundraiser.Owner = ownerRepo;
            fundraiser.DonationTarget = GoalValue;
            fundraiser.DueDate = dueDate;
            await _fundraiserRepository.Update(fundraiser);

        }

        public async Task<Fundraiser> GetFundraiserAsync(int fundraiserId)
        {
            var fundraiser = await _fundraiserRepository.GetById(fundraiserId);

            if (fundraiser == null)
            {
                throw new ArgumentException();
            }
            fundraiser.Owner = await _personRepository.GetOrAddPersonAsync(fundraiser.Owner);
            if (fundraiser.Owner == null)
            {
                throw new ArgumentException();
            }
            return fundraiser.ToDomainModel();
        }

        public async Task<IReadOnlyList<Fundraiser>> GetAllFundraisersAsync()
        {
            var fundraisers = await _fundraiserRepository.GetAll();
            return fundraisers.Select(f=>f.ToDomainModel()).ToImmutableArray();
        }

        public async Task DonateToFundraiserAsync(int fundraiserId, Person donor, int donationValue)
        {
            var fundraiser = await GetFundraiserAsync(fundraiserId);

            if (fundraiser == null)
            {
                throw new ArgumentException($"Fundraiser with ID {fundraiserId} does not exist.");
            }

            if (donor == null)
            {
                throw new ArgumentNullException(nameof(donor));
            }

            if (donationValue <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(donationValue), "Donation value must be greater than 0.");
            }

            fundraiser.RaisedAmount += donationValue;

            if (fundraiser.RaisedAmount >= fundraiser.DonationTarget)
            {
                fundraiser.Status = FundraiserStatus.Closed;
            }

            if (!fundraiser.Donors.Contains(donor))
            {
                fundraiser.Donors.Add(donor);
            }
        }

        public async Task DeleteFundraiserAsync(int fundraiserId)
        {
            var fundraiser = await _fundraiserRepository.GetById(fundraiserId);

            if (fundraiser == null)
            {
                throw new ArgumentException($"Fundraiser with ID {fundraiserId} does not exist.");
            }

            fundraiser.Status = (DataAccessLayer.Models.FundraiserStatus)FundraiserStatus.Closed;
            var owner = await _personRepository.GetOrAddPersonAsync(fundraiser.Owner);
            await _personRepository.Delete(owner);
            await _fundraiserRepository.Delete(fundraiser);
        }

        
    }
}

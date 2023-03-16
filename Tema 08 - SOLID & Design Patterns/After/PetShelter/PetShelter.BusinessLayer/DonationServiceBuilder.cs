using FluentValidation;
using PetShelter.BusinessLayer.Tests;
using PetShelter.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.BusinessLayer
{
    public class DonationServiceBuilder
    {
        private IDonationRepository _donationRepository;
        private IValidator<AddDonationRequest> _donationValidator;

        public DonationServiceBuilder WithDonationRepository(IDonationRepository donationRepository)
        {
            _donationRepository = donationRepository;
            return this;
        }

        public DonationServiceBuilder WithDonationValidator(IValidator<AddDonationRequest> validator)
        {
            _donationValidator = validator;
            return this;
        }

        public DonationService Build()
        {
            if (_donationRepository == null) { throw new ArgumentNullException(nameof(_donationRepository)); }
            if (_donationValidator == null) { throw new ArgumentNullException(nameof(_donationValidator)); }

            return new DonationService(_donationRepository, _donationValidator);
        }
    }

}

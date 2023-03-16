namespace PetShelter.Api.Resources.Extensions
{
    public static class FundraiserExtensions
    {
        public static Domain.Fundraiser AsDomainModel(this Fundraiser fundraiser)
        {
            var owner=fundraiser.Owner.AsDomainModel();
            var domainModel=new Domain.Fundraiser(fundraiser.Name,fundraiser.DonationTarget,owner,fundraiser.DueDate);
            domainModel.Status = (Domain.FundraiserStatus)fundraiser.Status;
            domainModel.Id = fundraiser.Id;
            domainModel.CreationTime = fundraiser.CreationTime;
            domainModel.Description = fundraiser.Description;
            domainModel.RaisedAmount = fundraiser.TotalDonations;

            return domainModel;
        }

        public static IdentifiableFundraiser AsResource(this Domain.Fundraiser fundraiser)
        {
            return new IdentifiableFundraiser
            {
                Id = fundraiser.Id,
                Name = fundraiser.Name,
                Description = fundraiser.Description,
                DueDate = fundraiser.DueDate,
                CreationTime = fundraiser.CreationTime,
                TotalDonations = fundraiser.RaisedAmount,
                Status = Enum.Parse<FundraiserStatus>(fundraiser.Status.ToString()),
                Owner = fundraiser.Owner?.AsResource(),
                DonationTarget=fundraiser.DonationTarget,

            };
        }
       
    }
}

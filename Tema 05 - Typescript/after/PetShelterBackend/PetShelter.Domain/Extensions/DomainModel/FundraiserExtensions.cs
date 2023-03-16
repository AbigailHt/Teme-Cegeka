using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Extensions.DomainModel
{
    internal static class FundraiserExtensions
    {
        public static Fundraiser? ToDomainModel(this DataAccessLayer.Models.Fundraiser fundraiser) {

            if (fundraiser == null)
            {
                return null;
            }
            
            var person=fundraiser.Owner.ToDomainModel();
            var domainModel = new Fundraiser(name: fundraiser.Title, goalValue: fundraiser.DonationTarget, person, fundraiser.DueDate);
            domainModel.Status = (FundraiserStatus)fundraiser.Status;
            domainModel.Id= fundraiser.Id;
            domainModel.CreationTime = fundraiser.CreationTime;
            domainModel.Description=fundraiser.Description;
            domainModel.RaisedAmount = fundraiser.RaisedAmount;
            
            return domainModel;
        }
    }
}

using PetShelter.DataAccessLayer.Models;


namespace PetShelter.DataAccessLayer.Repository
{
    public interface IFundraiserRepository:IBaseRepository<Fundraiser>
    {
        decimal CalculateRaisedAmount(int fundraiserId);
        Fundraiser GetFundraiserByName(string name);
    }
}

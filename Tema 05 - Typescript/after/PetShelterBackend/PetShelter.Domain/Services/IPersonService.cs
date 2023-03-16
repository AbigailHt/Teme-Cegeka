using PetShelter.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Domain.Services
{
    public interface IPersonService
    {
        Task CreatePersonAsync(string name, string id);
        Task<Person> GetPersonAsync(string id);
        Task<IReadOnlyList<Person>> GetAllPersonsAsync();
        Task DeletePersonAsync(string id);
        Task UpdatePersonAsync(string id,Person person);
    }
}


using PetShelter.BusinessLayer.Constants;

namespace PetShelter.BusinessLayer.ExternalServices;

public class PetTypValidator : IPetTypeValidator
{
    public Task<bool> Validate(PetType petType)
    { 
        return Task.FromResult(Enum.IsDefined(typeof(PetType), petType));
    }
}

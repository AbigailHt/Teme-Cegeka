

using PetShelter.BusinessLayer.Constants;

namespace PetShelter.BusinessLayer.ExternalServices;

public interface IPetTypeValidator
{
    Task<bool> Validate(PetType petType);
}

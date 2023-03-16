using Microsoft.AspNetCore.Mvc;
using PetShelter.Api.Resources;
using PetShelter.Domain.Services;
using PetShelter.Api.Resources.Extensions;
using System.Collections.Immutable;

namespace PetShelter.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FundraisersController : ControllerBase
    {
        private readonly IFundraiserService _fundraiserService;
        private readonly IPersonService _personService;

        public FundraisersController(IFundraiserService fundraiserService, IPersonService personService)
        {
            this._fundraiserService = fundraiserService;
            _personService = personService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IReadOnlyList<Fundraiser>>> GetFundraisers()
        {
            var data = await this._fundraiserService.GetAllFundraisersAsync();
            return this.Ok(data.Select(f => f.AsResource()).ToImmutableArray());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Fundraiser>> GetFundraiser(int id)
        {
            var fundraiser = await this._fundraiserService.GetFundraiserAsync(id);
            if (fundraiser is null)
            {
                return this.NotFound();
            }

            return this.Ok(fundraiser.AsResource());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateFundraiser(string name, decimal goalValue,
            Person owner, DateTime dueDate)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            await _fundraiserService.CreateFundraiserAsync(name, goalValue, owner.AsDomainModel(), dueDate);
            return this.Ok();
            
        }

        [HttpPost("{id}/donate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DonateToFundraiserAsync(int id, Person donor, int donationValue)
        {
            var fundraiser = await _fundraiserService.GetFundraiserAsync(id);
            if (fundraiser == null)
            {
                return this.BadRequest(ModelState);
            }
            fundraiser.Owner=donor.AsDomainModel();
            fundraiser.RaisedAmount += donationValue;
            return this.Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteFundraiser(int id)
        {
            var fundraiser = await _fundraiserService.GetFundraiserAsync(id);
            if (fundraiser == null)
            {
                return this.BadRequest(ModelState);
            }
            await this._fundraiserService.DeleteFundraiserAsync(id);
            return this.Ok();
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.PrisingCommands;
using RentCar.Application.Features.Mediator.Queries.PricingQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPricings()
        {
            var query = new GetPricingQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            var query = new GetPricingByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing([FromBody] CreatePricingCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid Pricing data.");
            }
            await _mediator.Send(command);
            return Ok("Pricing created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing([FromBody] UpdatePricingCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid Pricing data.");
            }
            await _mediator.Send(command);
            return Ok("Pricing updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            // Assuming you have a command for deleting a Pricing
            var command = new RemovePricingCommand(id);
            await _mediator.Send(command);
            return Ok("Pricing deleted successfully.");
        }
    }
}

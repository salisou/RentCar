using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.LocationCommands;
using RentCar.Application.Features.Mediator.Queries.LocationQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var query = new GetLocationQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var query = new GetLocationByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid location data.");
            }
            await _mediator.Send(command);
            return Ok("Location created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid location data.");
            }
            await _mediator.Send(command);
            return Ok("Location updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            // Assuming you have a command for deleting a location
            var command = new RemoveLocationCommand(id);
            await _mediator.Send(command);
            return Ok("Location deleted successfully.");
        }
    }
}

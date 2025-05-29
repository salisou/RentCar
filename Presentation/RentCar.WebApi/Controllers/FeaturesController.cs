using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.FeatureCommands;
using RentCar.Application.Features.Mediator.Queries.FeatureQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetListFeatures()
        {
            var features = await _mediator.Send(new GetFeatureQuery());
            if (features == null || !features.Any())
            {
                return NotFound("No features found.");
            }
            return Ok(features);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var feature = await _mediator.Send(new GetFeatureByIdQuery(id));
            if (feature == null)
            {
                return NotFound($"Feature with ID {id} not found.");
            }
            return Ok(feature);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid feature data.");
            }
            await _mediator.Send(command);
            return Ok("Feature created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature([FromBody] CreateFeatureCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid feature data.");
            }
            await _mediator.Send(command);
            return Ok("Feature updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _mediator.Send(new RemoveFeatureCommand(id));
            return Ok($"Feature with ID {id} deleted successfully.");
        }
    }
}

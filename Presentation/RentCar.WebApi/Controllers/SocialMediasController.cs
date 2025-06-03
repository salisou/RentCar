using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.SocialMediaCommands;
using RentCar.Application.Features.Mediator.Queries.SocialMediaQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSocialMedias()
        {
            var query = new GetSocialMediaQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var query = new GetSocialMediaByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia([FromBody] CreateSocialMediaCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid SocialMedia data.");
            }
            await _mediator.Send(command);
            return Ok("SocialMedia created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia([FromBody] UpdateSocialMediaCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid SocialMedia data.");
            }
            await _mediator.Send(command);
            return Ok("SocialMedia updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            // Assuming you have a command for deleting a SocialMedia
            var command = new RemoveSocialMediaCommand(id);
            await _mediator.Send(command);
            return Ok("SocialMedia deleted successfully.");
        }
    }
}

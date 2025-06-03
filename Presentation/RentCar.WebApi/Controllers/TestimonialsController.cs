using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.TestimonialCommands;
using RentCar.Application.Features.Mediator.Queries.TestimonialQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestimonials()
        {
            var query = new GetTestimonialQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var query = new GetTestimonialByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial([FromBody] CreateTestimonialCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid Testimonial data.");
            }
            await _mediator.Send(command);
            return Ok("Testimonial created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial([FromBody] UpdateTestimonialCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid Testimonial data.");
            }
            await _mediator.Send(command);
            return Ok("Testimonial updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            // Assuming you have a command for deleting a Testimonial
            var command = new RemoveTestimonialCommand(id);
            await _mediator.Send(command);
            return Ok("Testimonial deleted successfully.");
        }
    }
}

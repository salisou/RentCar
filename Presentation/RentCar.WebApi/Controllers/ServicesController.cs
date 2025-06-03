using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.ServiceCommands;
using RentCar.Application.Features.Mediator.Queries.ServiceQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var query = new GetServiceQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var query = new GetServiceByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] CreateServiceCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid Service data.");
            }
            await _mediator.Send(command);
            return Ok("Service created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid Service data.");
            }
            await _mediator.Send(command);
            return Ok("Service updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            // Assuming you have a command for deleting a Service
            var command = new RemoveServiceCommand(id);
            await _mediator.Send(command);
            return Ok("Service deleted successfully.");
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentCar.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFooterAddresses()
        {
            var query = new GetFooterAddressQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddressById(int id)
        {
            var query = new GetFooterAddressByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                NotFound($"Footer address with ID {id} not found.");
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress([FromBody] CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer address created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFooterAddress(int id, [FromBody] UpdateFooterAddressCommand command)
        {
            if (id != command.FooterAddressId)
            {
                return BadRequest("ID mismatch.");
            }
            await _mediator.Send(command);
            return Ok("Footer address updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFooterAddress(int id)
        {
            var command = new RemoveFooterAddressCommand(id);
            await _mediator.Send(command);
            return Ok("Footer address deleted successfully.");
        }
    }
}

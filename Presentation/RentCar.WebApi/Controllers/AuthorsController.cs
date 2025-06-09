using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.AuthorCommands;
using RentCar.Application.Features.Mediator.Queries.AuthorQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAuthor()
        {
            var value = await _mediator.Send(new GetAuthorQuery());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var value = await _mediator.Send(new GetAuthorByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorCommand command)
        {
            if (command != null)
            {
                await _mediator.Send(command);
                return Ok("Auhtor Created successfully");
            }

            return BadRequest("Invalide Author data");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommand command)
        {
            if (command != null)
            {
                await _mediator.Send(command);
                return Ok("Author Updated successfully");
            }
            return BadRequest("Invalid Author data");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var command = new RemoveAuthorCommand(id);
            await _mediator.Send(command);
            return Ok("Author Deleted successfully");
        }
    }
}

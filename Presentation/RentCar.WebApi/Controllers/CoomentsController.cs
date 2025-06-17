using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.CommentCommands;
using RentCar.Application.Features.Mediator.Queries.CommentQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoomentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoomentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var value = await _mediator.Send(new GetCommentQuery());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var value = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentCommand command)
        {
            if (command != null)
            {
                await _mediator.Send(command);
                return Ok("Comment Created successfully");
            }
            return BadRequest("Invalid Comment data");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentCommand command)
        {
            if (command != null)
            {
                await _mediator.Send(command);
                return Ok("Comment Updated successfully");
            }
            return BadRequest("Invalid Comment data");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var command = new RemoveCommentCommand(id);
            await _mediator.Send(command);
            return Ok("Comment Deleted successfully");
        }

        [HttpGet]
        [Route("GetAllCommentWithAuthors")]
        public async Task<IActionResult> GetAllCommentWithAuthors()
        {
            var result = await _mediator.Send(new GetCommentByAuthroQuery());
            return Ok(result);
        }
    }
}

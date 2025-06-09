using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.BlogCommands;
using RentCar.Application.Features.Mediator.Queries.BlogQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetListBlog()
        {
            var value = await _mediator.Send(new GetBlogQuery());
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var value = await _mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command)
        {
            if (command != null)
            {
                await _mediator.Send(command);
                return Ok("Auhtor Created successfully");
            }

            return BadRequest("Invalide Blog data");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogCommand command)
        {
            if (command != null)
            {
                await _mediator.Send(command);
                return Ok("Blog Updated successfully");
            }
            return BadRequest("Invalid Blog data");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var command = new RemoveBlogCommand(id);
            await _mediator.Send(command);
            return Ok("Blog Deleted successfully");
        }
    }
}

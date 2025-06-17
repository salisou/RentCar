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
        public async Task<IActionResult> GetBlogs()
        {
            var query = new GetBlogQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var query = new GetBlogByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] CreateBlogCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid Blog data.");
            }
            await _mediator.Send(command);
            return Ok("Blog created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromBody] UpdateBlogCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid Blog data.");
            }
            await _mediator.Send(command);
            return Ok("Blog updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            // Assuming you have a command for deleting a Blog
            var command = new RemoveBlogCommand(id);
            await _mediator.Send(command);
            return Ok("Blog deleted successfully.");
        }

        [HttpGet("GetLast3BlogsWithAuthors")]
        public async Task<IActionResult> GetLast3BlogsWithAuthors()
        {
            var value = await _mediator.Send(new GetLast3BlosWithAuthorQuery());
            return Ok(value);
        }

        [HttpGet("GetAllBlogsWithAuthors")]
        public async Task<IActionResult> GetAllBlogsWithAuthors()
        {
            var value = await _mediator.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(value);
        }
    }
}

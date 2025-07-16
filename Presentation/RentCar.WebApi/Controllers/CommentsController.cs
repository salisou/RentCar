using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.RepositoryPattern.CommentRepositories;
using RentCar.Domain.Entities;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentsController(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var value = await _commentRepository.GetAllAsync();
            return Ok(value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var value = await _commentRepository.GetById(id);
            if (value == null)
            {
                return NotFound($"Comment with ID {id} not found.");
            }
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] Comment comment)
        {
            if (comment != null)
            {
                _commentRepository.Create(comment);
                return Ok("Comment Created successfully");
            }
            return BadRequest("Invalid Comment data");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] Comment comment)
        {
            if (comment == null || comment.CommentId <= 0 || comment.CommentId != id)
            {
                return BadRequest("Invalid comment data.");
            }
            var existingComment = _commentRepository.GetById(id);
            if (existingComment == null)
            {
                return NotFound($"Comment with ID {id} not found.");
            }
            _commentRepository.Update(comment);
            return Ok("Comment updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(Comment comment)
        {
            if (comment == null || comment.CommentId <= 0)
            {
                return BadRequest("Invalid comment data.");
            }
            var existingComment = _commentRepository.GetById(comment.CommentId);
            if (existingComment == null)
            {
                return NotFound($"Comment with ID {comment.CommentId} not found.");
            }
            _commentRepository.Delete(comment);
            return Ok("Comment deleted successfully.");
        }
    }
}

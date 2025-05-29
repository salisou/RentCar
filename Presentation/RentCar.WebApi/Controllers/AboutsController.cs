using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.CQRS.Commands.AboutsCommands;
using RentCar.Application.Features.CQRS.Handlers.AboutHandlers;
using RentCar.Application.Features.CQRS.Queries.AboutQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly GetAboutQueryHadler _getAboutQueryHandler;
        private readonly GetAboutByIdQueryHadler _getAboutByIdQueryHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly RemoveAboutCommandHandler _deleteAboutCommandHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, GetAboutQueryHadler getAboutQueryHandler, GetAboutByIdQueryHadler getAboutByIdQueryHandler, UpdateAboutCommandHandler updateAboutCommandHandler, RemoveAboutCommandHandler deleteAboutCommandHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _deleteAboutCommandHandler = deleteAboutCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var result = await _getAboutQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AboutById(int id)
        {
            var result = await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid command.");
            }
            await _createAboutCommandHandler.Handle(command);
            return Ok("About created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateAboutCommand command)
        {
            if (command == null || command.AboutId <= 0)
            {
                return BadRequest("Invalid command.");
            }

            await _updateAboutCommandHandler.Handle(command);
            return Ok("About updated successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            if (id <= 0) return BadRequest("Invalid ID.");

            await _deleteAboutCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("About deleted successfully.");
        }
    }
}

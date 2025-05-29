using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.CQRS.Commands.ContactCommands;
using RentCar.Application.Features.CQRS.Handlers.ContactHandlers;
using RentCar.Application.Features.CQRS.Queries.ContactQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var result = await _getContactQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ContactById(int id)
        {
            var result = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContactCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid command.");
            }
            await _createContactCommandHandler.Handle(command);
            return Ok("Contact created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContactCommand command)
        {
            if (command == null || command.ContactId <= 0)
            {
                return BadRequest("Invalid command.");
            }

            await _updateContactCommandHandler.Handle(command);
            return Ok("Contact updated successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            if (id <= 0) return BadRequest("Invalid ID.");

            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Contact deleted successfully.");
        }
    }
}

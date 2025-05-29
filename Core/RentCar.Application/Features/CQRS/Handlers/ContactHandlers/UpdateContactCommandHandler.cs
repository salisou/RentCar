using RentCar.Application.Features.CQRS.Commands.ContactCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateContactCommand command)
        {
            Contact? contact = await _repository.GetByIdAsync(command.ContactId);
            if (contact == null)
            {
                throw new KeyNotFoundException($"Contact with ID {command.ContactId} not found.");
            }

            contact.Name = command.Name;
            contact.Email = command.Email;
            contact.Subject = command.Subject;
            contact.Message = command.Message;
            contact.SendDate = command.SendDate;

            await _repository.RemoveAsync(contact);
        }
    }
}

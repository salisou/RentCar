using RentCar.Application.Features.CQRS.Commands.ContactCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveContactCommand command)
        {
            Contact? contact = await _repository.GetByIdAsync(command.Id);
            if (contact == null)
            {
                throw new KeyNotFoundException($"Contact with ID {command.Id} not found.");
            }
            await _repository.RemoveAsync(contact);
        }
    }
}

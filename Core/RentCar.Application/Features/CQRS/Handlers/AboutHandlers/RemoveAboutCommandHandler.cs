using RentCar.Application.Features.CQRS.Commands.AboutsCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAboutCommand command)
        {
            About? about = await _repository.GetByIdAsync(command.Id);
            if (about == null)
            {
                throw new KeyNotFoundException($"About with ID {command.Id} not found.");
            }
            await _repository.RemoveAsync(about);
        }
    }
}

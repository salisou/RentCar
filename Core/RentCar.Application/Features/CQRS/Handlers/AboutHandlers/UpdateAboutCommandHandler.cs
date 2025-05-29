using RentCar.Application.Features.CQRS.Commands.AboutsCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            About? about = await _repository.GetByIdAsync(command.AboutId);
            if (about == null)
            {
                throw new KeyNotFoundException($"About with ID {command.AboutId} not found.");
            }
            about.Title = command.Title;
            about.Description = command.Description;
            about.ImageUrl = command.ImageUrl;
            await _repository.UpdateAsync(about);
        }
    }
}

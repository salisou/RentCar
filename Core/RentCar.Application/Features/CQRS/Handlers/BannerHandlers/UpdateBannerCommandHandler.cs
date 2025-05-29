using RentCar.Application.Features.CQRS.Commands.BannerCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand command)
        {
            Banner? value = await _repository.GetByIdAsync(command.BannerId);
            if (value == null)
            {
                throw new KeyNotFoundException($"Banner with ID {command.BannerId} not found.");
            }
            value.Title = command.Title;
            value.Description = command.Description;
            value.VideoDescription = command.VideoDescription;
            value.VideoUrl = command.VideoUrl;

            await _repository.UpdateAsync(value);
        }
    }
}

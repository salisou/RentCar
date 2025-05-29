﻿using RentCar.Application.Features.CQRS.Commands.BannerCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBannerCommand command)
        {
            Banner? banner = await _repository.GetByIdAsync(command.Id);
            if (banner == null)
            {
                throw new KeyNotFoundException($"Banner with ID {command.Id} not found.");
            }
            await _repository.RemoveAsync(banner);
        }
    }
}

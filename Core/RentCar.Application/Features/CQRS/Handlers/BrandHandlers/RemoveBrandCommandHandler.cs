using RentCar.Application.Features.CQRS.Commands.BrandCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handler(RemoveBrandCommand command)
        {
            Brand? brand = await _repository.GetByIdAsync(command.Id);
            if (brand == null)
            {
                throw new KeyNotFoundException($"Brand with ID {command.Id} not found.");
            }
            await _repository.RemoveAsync(brand);
        }
    }
}

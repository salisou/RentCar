using RentCar.Application.Features.CQRS.Commands.BrandCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handler(UpdateBrandCommand command)
        {
            Brand? brand = await _repository.GetByIdAsync(command.BrandId);
            if (brand == null)
            {
                throw new KeyNotFoundException($"Brand with ID {command.BrandId} not found.");
            }
            brand.Name = command.Name;
            await _repository.UpdateAsync(brand);
        }
    }
}

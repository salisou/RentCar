using RentCar.Application.Features.CQRS.Commands.BrandCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;
        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBrandCommand createBrandCommand)
        {
            await _repository.CreateAsync(new Brand
            {
                Name = createBrandCommand.Name
            });
        }
    }
}

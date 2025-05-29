using RentCar.Application.Features.CQRS.Commands.CarCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;
        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarCommand command)
        {
            Car? car = await _repository.GetByIdAsync(command.Id);
            if (car == null)
            {
                throw new KeyNotFoundException($"Car with ID {command.Id} not found.");
            }
            _repository.RemoveAsync(car).Wait();
        }
    }
}

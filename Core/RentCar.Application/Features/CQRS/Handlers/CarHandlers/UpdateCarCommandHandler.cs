using RentCar.Application.Features.CQRS.Commands.CarCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarCommand request)
        {
            var car = await _repository.GetByIdAsync(request.CarId);

            // Update car properties
            car!.BrandId = request.BrandId;
            car.Model = request.Model;
            car.CoverImageUrl = request.CoverImageUrl;
            car.Km = request.Km;
            car.Transmission = request.Transmission;
            car.Seat = request.Seat;
            car.Luggage = request.Luggage;
            car.Fuel = request.Fuel;
            car.BigImageUrl = request.BigImageUrl;

        }
    }
}

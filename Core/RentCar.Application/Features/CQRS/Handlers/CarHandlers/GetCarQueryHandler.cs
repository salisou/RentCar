using RentCar.Application.Features.CQRS.Results.CarResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarByIdQueryResult>> Handle()
        {
            List<Car> cars = await _repository.GetAllAsync();
            var result = cars.Select(c => new GetCarByIdQueryResult
            {
                CarId = c.CarId,
                BrandId = c.BrandId,
                Model = c.Model,
                CoverImageUrl = c.CoverImageUrl,
                BigImageUrl = c.BigImageUrl,
                Fuel = c.Fuel,
                Km = c.Km,
                Luggage = c.Luggage,
                Seat = c.Seat,
                Transmission = c.Transmission
            }).ToList();

            return result;
        }
    }
}

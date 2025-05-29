using RentCar.Application.Features.CQRS.Queries.CarQueries;
using RentCar.Application.Features.CQRS.Results.CarResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handler(GetCarByIdQuery query)
        {
            var car = await _repository.GetByIdAsync(query.Id);
            if (car != null)
            {

                return new GetCarByIdQueryResult
                {
                    CarId = car.CarId,
                    BrandId = car.BrandId,
                    Model = car.Model,
                    CoverImageUrl = car.CoverImageUrl,
                    Km = car.Km,
                    Transmission = car.Transmission,
                    Seat = car.Seat,
                    Luggage = car.Luggage,
                    Fuel = car.Fuel,
                    BigImageUrl = car.BigImageUrl
                };
            }
            return null!;
        }
    }
}

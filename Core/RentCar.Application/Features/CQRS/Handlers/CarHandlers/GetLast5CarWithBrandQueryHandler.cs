using RentCar.Application.Features.CQRS.Results.CarResults;
using RentCar.Application.Interfaces.CarInterfaces;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetLast5CarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<GetLast5CarsWithBrandQueryResult> Handler()
        {
            var values = _carRepository.GetLast5CarsWithBrands();
            return values.Select(c => new GetLast5CarsWithBrandQueryResult
            {
                CarId = c.CarId,
                BrandId = c.BrandId,
                BrandName = c.Brand.Name,
                Model = c.Model,
                CoverImageUrl = c.CoverImageUrl,
                BigImageUrl = c.BigImageUrl,
                Fuel = c.Fuel,
                Km = c.Km,
                Luggage = c.Luggage,
                Seat = c.Seat,
                Transmission = c.Transmission
            }).ToList();
        }
    }
}

using RentCar.Application.Features.CQRS.Results.CarResults;
using RentCar.Application.Interfaces.CarInterfaces;

namespace RentCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<GetCarWithBrandQueryResult> Handler()
        {
            var values = _carRepository.GetCarsListWithBrands();
            return values.Select(c => new GetCarWithBrandQueryResult
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

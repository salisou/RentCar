using MediatR;
using RentCar.Application.Features.Mediator.Queries.CarpricingQueries;
using RentCar.Application.Features.Mediator.Results.CarPricingResults;
using RentCar.Application.Interfaces.CarPricingInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.CarpricingHandlers
{
    public class GetCarpricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarpricingWithCarQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var carPricings = await _repository.GetCarPricingWithCars();
            var result = carPricings.Select(cp => new GetCarPricingWithCarQueryResult
            {
                CarPricinId = cp.CarPricingId,
                Brand = cp.Car.Brand.Name,
                Model = cp.Car.Model,
                Amount = cp.Amount,
                CoverImangeUrl = cp.Car.CoverImageUrl
            }).ToList();
            return result;
        }
    }
}

using MediatR;
using RentCar.Application.Features.Mediator.Results.CarPricingResults;

namespace RentCar.Application.Features.Mediator.Queries.CarpricingQueries
{
    public class GetCarPricingWithCarQuery : IRequest<List<GetCarPricingWithCarQueryResult>>
    {
    }
}

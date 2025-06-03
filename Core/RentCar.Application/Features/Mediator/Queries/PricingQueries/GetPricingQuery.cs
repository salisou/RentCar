using MediatR;
using RentCar.Application.Features.Mediator.Results.PrisingResults;

namespace RentCar.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery : IRequest<List<GetPricingQueryResult>>
    {
    }
}

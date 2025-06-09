using MediatR;
using RentCar.Application.Features.Mediator.Results.BloagResults;

namespace RentCar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogQuery : IRequest<List<GetBlogQueryResult>>
    {
    }
}

using MediatR;
using RentCar.Application.Features.Mediator.Results.BlogResults;

namespace RentCar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetLast3BlosWithAuthorQuery : IRequest<List<GetLast3BlosWithAuthorQueryResult>>
    {
    }
}

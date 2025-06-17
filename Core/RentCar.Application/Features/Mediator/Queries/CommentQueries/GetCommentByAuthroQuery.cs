using MediatR;
using RentCar.Application.Features.Mediator.Results.CommentResults;

namespace RentCar.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentByAuthroQuery : IRequest<List<GetCommentByAuthroQueryResult>>
    {
    }
}

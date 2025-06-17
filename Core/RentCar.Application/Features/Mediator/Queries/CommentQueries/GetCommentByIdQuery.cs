using MediatR;
using RentCar.Application.Features.Mediator.Results.CommentResults;

namespace RentCar.Application.Features.Mediator.Queries.CommentQueries
{
    public class GetCommentByIdQuery : IRequest<GetCommentByIdQueryResult>
    {
        public int Id { get; set; }
        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}

using MediatR;
using RentCar.Application.Features.Mediator.Results.BlogResults;

namespace RentCar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetBlogByAuthorIdQuery : IRequest<List<GetBlogByAuthorIdQueryResult>>
    {
        public int AuthorId { get; set; }
        public GetBlogByAuthorIdQuery(int authorId)
        {
            AuthorId = authorId;
        }
    }
}

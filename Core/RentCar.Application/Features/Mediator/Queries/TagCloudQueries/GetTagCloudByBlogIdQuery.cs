using MediatR;
using RentCar.Application.Features.Mediator.Results.TagCloudResults;

namespace RentCar.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudByBlogIdQuery : IRequest<List<GetTagCloudByBlogIdQueryResult>>
    {
        public int BlogId { get; set; }
        public GetTagCloudByBlogIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}

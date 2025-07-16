using MediatR;
using RentCar.Application.Features.Mediator.Queries.TagCloudQueries;
using RentCar.Application.Features.Mediator.Results.TagCloudResults;
using RentCar.Application.Interfaces.TagCloudInterfaces;

namespace RentCar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _tagCloudRepository;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var tagClouds = await _tagCloudRepository.GetTagCloudsByBlogId(request.BlogId);
            if (tagClouds == null || !tagClouds.Any())
            {
                throw new KeyNotFoundException($"No tag clouds found for blog ID {request.BlogId}.");
            }

            // Log or debug the tagClouds to inspect the Blog property
            foreach (var tagCloud in tagClouds)
            {
                Console.WriteLine($"TagCloudId: {tagCloud.TagCloudId}, BlogId: {tagCloud.BlogId}, Blog: {tagCloud.Blog?.ToString()}");
            }

            return tagClouds.Select(tc => new GetTagCloudByBlogIdQueryResult
            {
                TagCloudId = tc.TagCloudId,
                BlogId = tc.BlogId,
                Title = tc.Title
            }).ToList();
        }
    }
}

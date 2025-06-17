using MediatR;
using RentCar.Application.Features.Mediator.Queries.TagCloudQueries;
using RentCar.Application.Features.Mediator.Results.TagCloudResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCLoudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _tagCloudRepository;

        public GetTagCLoudQueryHandler(IRepository<TagCloud> tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var getData = await _tagCloudRepository.GetAllAsync();
            return getData.Select(x => new GetTagCloudQueryResult
            {
                TagCloudId = x.TagCloudId,
                Title = x.Title,
                BlogId = x.BlogId
            }).ToList();
        }
    }
}

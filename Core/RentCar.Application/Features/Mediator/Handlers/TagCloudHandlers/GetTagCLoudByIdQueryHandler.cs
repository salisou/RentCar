using MediatR;
using RentCar.Application.Features.Mediator.Queries.TagCloudQueries;
using RentCar.Application.Features.Mediator.Results.TagCloudResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCLoudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _tagCloudRepository;

        public GetTagCLoudByIdQueryHandler(IRepository<TagCloud> tagCloudRepository)
        {
            _tagCloudRepository = tagCloudRepository;
        }

        public Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var getData = _tagCloudRepository.GetByIdAsync(request.Id);
            if (getData == null)
            {
                throw new KeyNotFoundException($"TagCloud with ID {request.Id} not found.");
            }
            return Task.FromResult(new GetTagCloudByIdQueryResult
            {
                TagCloudId = getData.Result!.TagCloudId,
                Title = getData.Result.Title,
                BlogId = getData.Result.BlogId
            });
        }
    }
}

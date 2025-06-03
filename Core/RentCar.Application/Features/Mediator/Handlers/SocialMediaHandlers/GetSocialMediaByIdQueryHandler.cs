using MediatR;
using RentCar.Application.Features.Mediator.Queries.SocialMediaQueries;
using RentCar.Application.Features.Mediator.Results.SocialMediaResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repo;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repo)
        {
            this._repo = repo;
        }

        public Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                var service = await _repo.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException($"Service with ID {request.Id} not found.");
                return new GetSocialMediaByIdQueryResult
                {
                    Icon = service.Icon,
                    Link = service.Link,
                    Name = service.Name,
                    SocialMediaId = service.SocialMediaId,
                    Url = service.Url
                };
            }, cancellationToken);
        }
    }
}

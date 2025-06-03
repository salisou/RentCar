using MediatR;
using RentCar.Application.Features.Mediator.Queries.SocialMediaQueries;
using RentCar.Application.Features.Mediator.Results.SocialMediaResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repo;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repo)
        {
            _repo = repo;
        }

        public Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                var socialMedias = await _repo.GetAllAsync();
                return socialMedias.Select(sm => new GetSocialMediaQueryResult
                {
                    SocialMediaId = sm.SocialMediaId,
                    Name = sm.Name,
                    Url = sm.Url,
                    Icon = sm.Icon,
                    Link = sm.Link
                }).ToList();
            }, cancellationToken);
        }
    }
}

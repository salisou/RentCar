using MediatR;
using RentCar.Application.Features.Mediator.Queries.PricingQueries;
using RentCar.Application.Features.Mediator.Results.PrisingResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.PrisingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> _repo;
        public GetPricingQueryHandler(IRepository<Pricing> repo)
        {
            _repo = repo;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repo.GetAllAsync();
            return values.Select(x => new GetPricingQueryResult
            {
                PricingId = x.PricingId,
                Name = x.Name
            }).ToList();
        }
    }
}

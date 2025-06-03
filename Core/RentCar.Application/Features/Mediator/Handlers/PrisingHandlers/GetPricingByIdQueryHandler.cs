using MediatR;
using RentCar.Application.Features.Mediator.Queries.PricingQueries;
using RentCar.Application.Features.Mediator.Results.PrisingResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.PrisingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id)
                .ContinueWith(task =>
                {
                    var pricing = task.Result ?? throw new KeyNotFoundException($"Pricing with ID {request.Id} not found.");
                    return new GetPricingByIdQueryResult
                    {
                        PricingId = pricing!.PricingId,
                        Name = pricing.Name
                    };
                }, cancellationToken);
        }
    }
}

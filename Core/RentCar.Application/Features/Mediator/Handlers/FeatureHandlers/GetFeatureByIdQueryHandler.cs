using MediatR;
using RentCar.Application.Features.Mediator.Queries.FeatureQueries;
using RentCar.Application.Features.Mediator.Results.FeatureResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            _repository = repository;
        }

        public Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetByIdAsync(request.Id) ?? throw new Exception("Feature not found");
            var result = new GetFeatureByIdQueryResult
            {
                FeatureId = value.Result!.FeatureId,
                Name = value.Result.Name,
            };
            return Task.FromResult(result);
        }
    }
}

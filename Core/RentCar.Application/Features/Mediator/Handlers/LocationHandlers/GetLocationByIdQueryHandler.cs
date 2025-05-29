using MediatR;
using RentCar.Application.Features.Mediator.Queries.LocationQueries;
using RentCar.Application.Features.Mediator.Results.LocationResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repo;

        public GetLocationByIdQueryHandler(IRepository<Location> repo)
        {
            _repo = repo;
        }

        public Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = _repo.GetByIdAsync(request.Id);
            if (location == null)
            {
                return Task.FromResult<GetLocationByIdQueryResult>(null!);
            }
            var result = new GetLocationByIdQueryResult
            {
                LocationId = location.Result!.LocationId,
                Name = location.Result.Name
            };
            return Task.FromResult(result);
        }
    }
}

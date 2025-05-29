using MediatR;
using RentCar.Application.Features.Mediator.Queries.LocationQueries;
using RentCar.Application.Features.Mediator.Results.LocationResults;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly IRepository<Location> _repo;

        public GetLocationQueryHandler(IRepository<Location> repo)
        {
            _repo = repo;
        }

        public Task<List<GetLocationQueryResult>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var locations = _repo.GetAllAsync();
            var result = locations.Result.Select(location => new GetLocationQueryResult
            {
                LocationId = location.LocationId,
                Name = location.Name
            }).ToList();

            return Task.FromResult(result);
        }
    }
}

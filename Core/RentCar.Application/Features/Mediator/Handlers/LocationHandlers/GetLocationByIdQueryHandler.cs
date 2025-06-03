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
            var location = _repo.GetByIdAsync(request.Id)
                .ContinueWith(task =>
                {
                    var loc = task.Result;
                    return new GetLocationByIdQueryResult
                    {
                        LocationId = loc!.LocationId,
                        Name = loc.Name
                    };
                }, cancellationToken);
            return location;
        }
    }
}

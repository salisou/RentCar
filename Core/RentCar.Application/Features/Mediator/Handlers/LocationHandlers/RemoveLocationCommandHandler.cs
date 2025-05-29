using MediatR;
using RentCar.Application.Features.Mediator.Commands.LocationCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
    {
        private readonly IRepository<Location> _locationRepository;

        public RemoveLocationCommandHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
        {
            Location? location = await _locationRepository.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"Location with ID {request.Id} not found.");
            await _locationRepository.RemoveAsync(location);
        }
    }
}

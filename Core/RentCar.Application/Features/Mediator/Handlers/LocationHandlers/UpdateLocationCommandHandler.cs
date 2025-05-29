using MediatR;
using RentCar.Application.Features.Mediator.Commands.LocationCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _locationRepository;

        public UpdateLocationCommandHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _locationRepository.GetByIdAsync(request.LocationId) ??
                throw new Exception("Location not found");
            // Update the location properties
            location.Name = request.Name;
            await _locationRepository.UpdateAsync(location);
        }
    }
}

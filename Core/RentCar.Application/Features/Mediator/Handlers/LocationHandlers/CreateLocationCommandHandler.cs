using MediatR;
using RentCar.Application.Features.Mediator.Commands.LocationCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly IRepository<Location> _locationRepository;

        public CreateLocationCommandHandler(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            await _locationRepository.CreateAsync(new Location
            {
                Name = request.Name
            });
        }
    }
}

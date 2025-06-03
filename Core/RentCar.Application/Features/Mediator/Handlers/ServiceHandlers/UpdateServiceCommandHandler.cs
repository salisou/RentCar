using MediatR;
using RentCar.Application.Features.Mediator.Commands.ServiceCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> _repository;
        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            Service? service = await _repository.GetByIdAsync(request.ServiceId) ??
                throw new KeyNotFoundException($"Service with ID {request.ServiceId} not found.");

            service.Title = request.Title;
            service.Description = request.Description;
            service.ImageUrl = request.ImageUrl;
            await _repository.UpdateAsync(service);
        }
    }
}

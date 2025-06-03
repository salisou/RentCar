using MediatR;
using RentCar.Application.Features.Mediator.Commands.PrisingCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.PrisingHandlers
{
    public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> _repo;

        public RemovePricingCommandHandler(IRepository<Pricing> repo)
        {
            _repo = repo;
        }

        public Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var value = _repo.GetByIdAsync(request.Id).Result ??
                throw new KeyNotFoundException($"Pricing with ID {request.Id} not found.");
            return _repo.RemoveAsync(value);
        }
    }
}

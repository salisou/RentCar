using MediatR;
using RentCar.Application.Features.Mediator.Commands.PrisingCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.PrisingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repo;

        public UpdatePricingCommandHandler(IRepository<Pricing> repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repo.GetByIdAsync(request.PricingId) ??
                throw new KeyNotFoundException($"Pricing with ID {request.PricingId} not found.");
            value.Name = request.Name;

            await _repo.UpdateAsync(value);
        }
    }
}

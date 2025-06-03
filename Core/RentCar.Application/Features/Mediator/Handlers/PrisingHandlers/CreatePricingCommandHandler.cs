using MediatR;
using RentCar.Application.Features.Mediator.Commands.PrisingCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.PrisingHandlers
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
    {
        private readonly IRepository<Pricing> _repo;

        public CreatePricingCommandHandler(IRepository<Pricing> repo)
        {
            _repo = repo;
        }

        public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            await _repo.CreateAsync(new Pricing
            {
                Name = request.Name
            });
        }
    }
}

using MediatR;
using RentCar.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class RemoveFooterAddressCommandHandlers : IRequestHandler<RemoveFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _prepo;

        public RemoveFooterAddressCommandHandlers(IRepository<FooterAddress> prepo)
        {
            _prepo = prepo;
        }

        public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
        {
            FooterAddress value = await _prepo.GetByIdAsync(request.Id) ??
                throw new KeyNotFoundException($"FooterAddress with ID {request.Id} not found.");
            await _prepo.RemoveAsync(value);
        }
    }
}

using MediatR;
using RentCar.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandlers : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repo;

        public CreateFooterAddressCommandHandlers(IRepository<FooterAddress> repo)
        {
            _repo = repo;
        }

        public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            await _repo.CreateAsync(new FooterAddress
            {
                Description = request.Description,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            });
        }
    }
}

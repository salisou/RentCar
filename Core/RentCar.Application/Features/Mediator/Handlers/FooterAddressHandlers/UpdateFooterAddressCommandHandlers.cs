using MediatR;
using RentCar.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandlers : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandlers(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetByIdAsync(request.FooterAddressId) ??
                throw new Exception("Footer address not found");

            // Update the footer address properties
            footerAddress.Description = request.Description;
            footerAddress.Address = request.Address;
            footerAddress.PhoneNumber = request.PhoneNumber;
            footerAddress.Email = request.Email;

            await _repository.UpdateAsync(footerAddress);
        }
    }
}

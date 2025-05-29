using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.FooterAddressCommands
{
    public class UpdateFooterAddressCommand : IRequest
    {
        public int FooterAddressId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}

using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.PrisingCommands
{
    public class UpdatePricingCommand : IRequest
    {
        public int PricingId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

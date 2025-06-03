using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.PrisingCommands
{
    public class CreatePricingCommand : IRequest
    {
        public string Name { get; set; } = string.Empty;
    }
}

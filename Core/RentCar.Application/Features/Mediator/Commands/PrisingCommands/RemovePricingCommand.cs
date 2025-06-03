using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.PrisingCommands
{
    public class RemovePricingCommand : IRequest
    {
        public int Id { get; set; }
        public RemovePricingCommand(int id)
        {
            Id = id;
        }
    }
}

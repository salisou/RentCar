using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.ServiceCommands
{
    public class UpdateServiceCommand : IRequest
    {
        public int ServiceId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}

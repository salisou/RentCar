using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.TagCloudCommands
{
    public class CreateTagCloudCommand : IRequest<Unit>
    {
        public string Title { get; set; } = string.Empty;
        public int BlogId { get; set; }
    }
}

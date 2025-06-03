using MediatR;

namespace RentCar.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class UpdateTestimonialCommand : IRequest
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}

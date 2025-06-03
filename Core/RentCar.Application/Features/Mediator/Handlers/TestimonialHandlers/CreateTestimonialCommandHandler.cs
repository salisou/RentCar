using MediatR;
using RentCar.Application.Features.Mediator.Commands.TestimonialCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _testimonialRepository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            await _testimonialRepository.CreateAsync(new Testimonial
            {
                Name = request.Name,
                Title = request.Title,
                Content = request.Content,
                ImageUrl = request.ImageUrl
            });
        }
    }
}

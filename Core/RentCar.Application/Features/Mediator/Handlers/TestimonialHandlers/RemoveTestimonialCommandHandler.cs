using MediatR;
using RentCar.Application.Features.Mediator.Commands.TestimonialCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _prepo;

        public RemoveTestimonialCommandHandler(IRepository<Testimonial> testimonialRepository)
        {
            _prepo = testimonialRepository;
        }

        public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
        {
            Testimonial value = await _prepo.GetByIdAsync(request.Id) ??
               throw new KeyNotFoundException($"Testimonial with ID {request.Id} not found.");
            await _prepo.RemoveAsync(value);
        }
    }
}

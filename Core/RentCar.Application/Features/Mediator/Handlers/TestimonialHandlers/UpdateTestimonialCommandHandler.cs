using MediatR;
using RentCar.Application.Features.Mediator.Commands.TestimonialCommands;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repo;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repo)
        {
            _repo = repo;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repo.GetByIdAsync(request.TestimonialId) ??
                throw new KeyNotFoundException("Testimonial not found");
            value.Name = request.Name;
            value.Title = request.Title;
            value.Content = request.Content;
            value.ImageUrl = request.ImageUrl;

            await _repo.UpdateAsync(value);
        }
    }
}

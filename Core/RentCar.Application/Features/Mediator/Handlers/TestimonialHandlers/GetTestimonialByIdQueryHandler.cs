using MediatR;
using RentCar.Application.Features.Mediator.Queries.TestimonialQueries;
using RentCar.Application.Features.Mediator.Results.TestimonialResluts;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryReslut>
    {
        private readonly IRepository<Testimonial> _repo;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repo)
        {
            _repo = repo;
        }

        public async Task<GetTestimonialByIdQueryReslut> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id)
                .ContinueWith(task =>
                {
                    var testimonial = task.Result;
                    return new GetTestimonialByIdQueryReslut
                    {
                        TestimonialId = testimonial!.TestimonialId,
                        Name = testimonial.Name,
                        Title = testimonial.Title,
                        Content = testimonial.Content,
                        ImageUrl = testimonial.ImageUrl
                    };
                }, cancellationToken);
        }
    }
}

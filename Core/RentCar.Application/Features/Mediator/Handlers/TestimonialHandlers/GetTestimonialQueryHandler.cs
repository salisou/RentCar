using MediatR;
using RentCar.Application.Features.Mediator.Queries.TestimonialQueries;
using RentCar.Application.Features.Mediator.Results.TestimonialResluts;
using RentCar.Application.Interfaces;
using RentCar.Domain.Entities;

namespace RentCar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryReslut>>
    {
        private readonly IRepository<Testimonial> _repo;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repo)
        {
            _repo = repo;
        }

        public Task<List<GetTestimonialQueryReslut>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = _repo.GetAllAsync()
                .ContinueWith(task => task.Result.Select(x => new GetTestimonialQueryReslut
                {
                    TestimonialId = x.TestimonialId,
                    Name = x.Name,
                    Title = x.Title,
                    Content = x.Content,
                    ImageUrl = x.ImageUrl
                }).ToList(),
                cancellationToken);

            return values;
        }
    }
}

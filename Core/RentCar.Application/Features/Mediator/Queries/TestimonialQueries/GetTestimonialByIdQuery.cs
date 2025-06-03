using MediatR;
using RentCar.Application.Features.Mediator.Results.TestimonialResluts;

namespace RentCar.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdQueryReslut>
    {
        public int Id { get; set; }
        public GetTestimonialByIdQuery(int id)
        {
            Id = id;
        }
    }
}

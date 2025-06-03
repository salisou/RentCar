using MediatR;
using RentCar.Application.Features.Mediator.Results.TestimonialResluts;

namespace RentCar.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryReslut>>
    {
    }
}

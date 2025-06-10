using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Queries.CarpricingQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarPricingsWithCars()
        {
            var result = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(result);
        }
    }
}

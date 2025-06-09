using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.CQRS.Commands.CarCommands;
using RentCar.Application.Features.CQRS.Handlers.CarHandlers;
using RentCar.Application.Features.CQRS.Queries.CarQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _removeCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLast5CarWithBrandQueryHandler _getLast5CarWithBrandQueryHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler, RemoveCarCommandHandler removeCarCommandHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, GetCarWithBrandQueryHandler getCarWithBrandQueryHandler, GetLast5CarWithBrandQueryHandler getLast5CarWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _removeCarCommandHandler = removeCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLast5CarWithBrandQueryHandler = getLast5CarWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarsList()
        {
            var result = await _getCarQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var result = await _getCarByIdQueryHandler.Handler(new GetCarByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] CreateCarCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid command.");
            }
            await _createCarCommandHandler.Handler(command);
            return Ok("Car created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommand command)
        {
            if (command == null || command.CarId <= 0)
            {
                return BadRequest("Invalid command.");
            }
            await _updateCarCommandHandler.Handle(command);
            return Ok("Car updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCar(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid car ID.");
            }

            await _removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Car removed successfully.");
        }

        [HttpGet("with-brand")]
        public IActionResult GetCarWithBrand()
        {
            var result = _getCarWithBrandQueryHandler.Handler();
            return Ok(result);
        }

        [HttpGet("GetLast5CarsWithBrands")]
        public IActionResult GetLast5CarsWithBrands()
        {
            var result = _getLast5CarWithBrandQueryHandler.Handler();
            if (result == null || !result.Any())
            {
                return NotFound("No cars found.");
            }
            return Ok(result);
        }
    }
}

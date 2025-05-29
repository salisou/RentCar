using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.CQRS.Commands.BrandCommands;
using RentCar.Application.Features.CQRS.Handlers.BrandHandlers;
using RentCar.Application.Features.CQRS.Queries.BrandQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly GetBrandQueryHandler _getbrandQueryHandler;

        public BrandsController(CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, GetBrandQueryHandler getbrandQueryHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _getbrandQueryHandler = getbrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandsLList()
        {
            var result = await _getbrandQueryHandler.Handler();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var result = await _getBrandByIdQueryHandler.Handler(new GetBrandByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand([FromBody] CreateBrandCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid command.");
            }
            await _createBrandCommandHandler.Handle(command);
            return Ok("Brand created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] UpdateBrandCommand command)
        {
            if (command == null || command.BrandId <= 0)
            {
                return BadRequest("Invalid command.");
            }
            await _updateBrandCommandHandler.Handler(command);
            return Ok("Brand updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid brand ID.");
            }
            await _removeBrandCommandHandler.Handler(new RemoveBrandCommand(id));
            return Ok("Brand removed successfully.");
        }
    }
}

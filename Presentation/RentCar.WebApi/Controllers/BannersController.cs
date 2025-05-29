using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.CQRS.Commands.BannerCommands;
using RentCar.Application.Features.CQRS.Handlers.BannerHandlers;
using RentCar.Application.Features.CQRS.Queries.BannerQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        readonly CreateBannerCommandHandler _createBannerCommandHandler;
        readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        readonly GetBannerQueryHandler _getBannerQueryHandler;

        public BannersController(CreateBannerCommandHandler createBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var result = await _getBannerQueryHandler.Handler();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BannerById(int id)
        {
            var result = await _getBannerByIdQueryHandler.Handler(new GetBannerByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner([FromBody] CreateBannerCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid command.");
            }
            await _createBannerCommandHandler.Handle(command);
            return Ok("Banner created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout([FromBody] UpdateBannerCommand command)
        {
            if (command == null || command.BannerId <= 0)
            {
                return BadRequest("Invalid command.");
            }

            await _updateBannerCommandHandler.Handle(command);
            return Ok("Banner updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            if (id <= 0) return BadRequest("Invalid ID.");

            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner deleted successfully.");
        }
    }
}

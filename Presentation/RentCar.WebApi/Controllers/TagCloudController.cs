using MediatR;
using Microsoft.AspNetCore.Mvc;
using RentCar.Application.Features.Mediator.Commands.TagCloudCommands;
using RentCar.Application.Features.Mediator.Queries.TagCloudQueries;

namespace RentCar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TagCloudController> _logger;

        public TagCloudController(IMediator mediator, ILogger<TagCloudController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTagClouds()
        {
            try
            {
                var value = await _mediator.Send(new GetTagCloudQuery());
                if (value == null || !value.Any())
                {
                    _logger.LogInformation("Nessun TagCloud trovato.");
                    return NotFound("No TagClouds found");
                }
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante il recupero dei TagClouds.");
                return StatusCode(500, "Si è verificato un errore interno.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTagCloudById(int id)
        {
            try
            {
                var value = await _mediator.Send(new GetTagCloudByIdQuery(id));
                if (value == null)
                {
                    _logger.LogInformation($"TagCloud con id {id} non trovato.");
                    return NotFound($"TagCloud with id {id} not found");
                }
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante il recupero del TagCloud con id {id}.");
                return StatusCode(500, "Si è verificato un errore interno.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTagCloud([FromBody] CreateTagCloudCommand command)
        {
            if (command == null)
            {
                _logger.LogWarning("Dati TagCloud non validi in CreateTagCloud.");
                return BadRequest("Invalid TagCloud data");
            }
            try
            {
                Unit? value = await _mediator.Send(command);
                if (value != null)
                {
                    return Ok("TagCloud Created successfully");
                }
                _logger.LogError("Errore durante la creazione del TagCloud.");
                return BadRequest("Failed to create TagCloud");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante la creazione del TagCloud.");
                return StatusCode(500, "Si è verificato un errore interno.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud([FromBody] UpdateTagCloudCommand command)
        {
            if (command == null)
            {
                _logger.LogWarning("Dati TagCloud non validi in UpdateTagCloud.");
                return BadRequest("Invalid TagCloud data");
            }
            try
            {
                await _mediator.Send(command);
                return Ok("TagCloud Updated successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'aggiornamento del TagCloud.");
                return StatusCode(500, "Si è verificato un errore interno.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagCloud(int id)
        {
            try
            {
                var command = new RemoveTagCloudCommand(id);
                await _mediator.Send(command);
                return Ok("TagCloud Deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Errore durante l'eliminazione del TagCloud con id {id}.");
                return StatusCode(500, "Si è verificato un errore interno.");
            }
        }
    }
}

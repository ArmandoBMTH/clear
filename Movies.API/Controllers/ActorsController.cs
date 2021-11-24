using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Application.Commands;
using Movies.Application.Queries;
using System.Threading.Tasks;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActorsController(IMediator mediator)
        {
            //Using dependency injection to use mediatR
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            //Get All Actors
            var result = await _mediator.Send(new GetAllActorsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Details(int id)
        {
            //Get details Actor
            var result = await _mediator.Send(new GetActorQuery() { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMovie([FromBody] CreateActorCommand command)
        {
            //Create a new Actor
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateActorCommand command)
        {
            //Update some actor
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            //Delete some actor
            var result = await _mediator.Send(new DeleteActorCommand() { Id = id });
            return Ok(result);
        }
    }
}

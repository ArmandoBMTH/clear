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
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            //Using dependency injection to use mediatR
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string search = "NONE")
        {
            //Validating if the user is doing a search or not
            if(search == "NONE")
            {
                var result = await _mediator.Send(new GetAllMoviesQuery());
                return Ok(result);
            }
            else
            {
                var result = await _mediator.Send(new GetAllMoviesTextQuery() { Search = search });
                return Ok(result);
            }
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Details(int id)
        {
            //Validating get movie details
            var result = await _mediator.Send(new GetMovieQuery() { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieCommand command)
        {
            //Create a new movie
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand command)
        {
            //Update some movie
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            //Delete some movie
            var result = await _mediator.Send(new DeleteMovieCommand() { Id = id });
            return Ok(result);
        }

        [HttpPost("addactor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddRelationActorMovie([FromBody] CreateActorMovieCommand command)
        {
            //Add relation actor with movie
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("removeactor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteRelationActorMovie([FromBody] DeleteActorMovieCommand command)
        {
            //Remove relation Actor with movie
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}

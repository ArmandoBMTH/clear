using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Commands
{
    public class CreateActorMovieCommand : IRequest<MovieDetailsResponse>
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
    }
}

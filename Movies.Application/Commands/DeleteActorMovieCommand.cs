using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Commands
{
    public class DeleteActorMovieCommand : IRequest<MovieDetailsResponse>
    {
        public int MovieId { get; set; }
        public string ActorName { get; set; }
    }
}
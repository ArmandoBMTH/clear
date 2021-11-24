using MediatR;

namespace Movies.Application.Commands
{
    public class DeleteMovieCommand : IRequest
    {
        public int Id { get; set; }
    }
}

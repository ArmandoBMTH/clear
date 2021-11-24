using MediatR;
using Movies.Application.Responses;

namespace Movies.Application.Queries
{
    public class GetMovieQuery : IRequest<MovieDetailsResponse>
    {
        public int Id { get; set; }
    }
}

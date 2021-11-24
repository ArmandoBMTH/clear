using MediatR;
using Movies.Application.Responses;
using System.Collections.Generic;

namespace Movies.Application.Queries
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<MovieReponse>>
    {
    }
}

using MediatR;
using Movies.Application.Responses;
using System.Collections.Generic;

namespace Movies.Application.Queries
{
    public class GetAllMoviesTextQuery : IRequest<IEnumerable<MovieReponse>>
    {
        public string Search { get; set; }
    }
}

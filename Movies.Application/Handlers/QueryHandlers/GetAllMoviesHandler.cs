using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.QueryHandlers
{
    public class GetAllMoviesHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieReponse>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMoviesHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieReponse>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var moviesEntity = await _movieRepository.GetAllAsync();
            var moviesReponse = MovieMapper.Mapper.Map<IEnumerable<MovieReponse>>(moviesEntity);
            return moviesReponse;
        }
    }
}

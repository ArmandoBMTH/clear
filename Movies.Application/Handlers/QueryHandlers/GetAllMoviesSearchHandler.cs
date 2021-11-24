using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.QueryHandlers
{
    public class GetAllMoviesSearchHandler : IRequestHandler<GetAllMoviesTextQuery, IEnumerable<MovieReponse>>
    {
        private readonly IMovieRepository _movieRepository;

        public GetAllMoviesSearchHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieReponse>> Handle(GetAllMoviesTextQuery request, CancellationToken cancellationToken)
        {
            var moviesEntity = await _movieRepository.GetMoviesBySomeTextAsync(request.Search);
            var moviesReponse = MovieMapper.Mapper.Map<IEnumerable<MovieReponse>>(moviesEntity);
            return moviesReponse;
        }
    }
}

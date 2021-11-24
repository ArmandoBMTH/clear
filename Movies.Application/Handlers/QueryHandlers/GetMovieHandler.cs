using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.QueryHandlers
{
    public class GetMovieHandler : IRequestHandler<GetMovieQuery, MovieDetailsResponse>
    {
        private readonly IMovieRepository _movieRepository;

        public GetMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailsResponse> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movieEntity = await _movieRepository.GetFullDataMovie(request.Id);
            if (movieEntity is null)
            {
                throw new ApplicationException("Cound't execute mapper");
            }
            
            var movieResponse = MovieMapper.Mapper.Map<MovieDetailsResponse>(movieEntity);
            return movieResponse;
        }
    }
}

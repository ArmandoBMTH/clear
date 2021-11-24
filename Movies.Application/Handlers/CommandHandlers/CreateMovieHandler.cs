using MediatR;
using Movies.Application.Commands;
using Movies.Application.Mappers;
using Movies.Application.Responses;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.CommandHandlers
{
    public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, MovieReponse>
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieReponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEntity = MovieMapper.Mapper.Map<Movie>(request);
            if(movieEntity is null)
            {
                throw new ApplicationException("Cound't execute mapper");
            }

            var newMovie = await _movieRepository.AddAsync(movieEntity);
            var movieResponse = MovieMapper.Mapper.Map<MovieReponse>(newMovie);
            return movieResponse;
        }
    }
}

using MediatR;
using Movies.Application.Commands;
using Movies.Application.Mappers;
using Movies.Application.Responses;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.CommandHandlers
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand, MovieReponse>
    {

        private readonly IMovieRepository _movieRepository;

        public UpdateMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MovieReponse> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEntity = MovieMapper.Mapper.Map<Movie>(request);
            if (movieEntity is null)
            {
                throw new ApplicationException("Cound't execute mapper");
            }

            var updateMovie = await _movieRepository.UpdateAsync(movieEntity);
            var movieReponse = MovieMapper.Mapper.Map<MovieReponse>(updateMovie);
            return movieReponse;
        }
    }
}

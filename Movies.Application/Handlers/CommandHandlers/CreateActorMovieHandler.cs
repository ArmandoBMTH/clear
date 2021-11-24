using MediatR;
using Movies.Application.Commands;
using Movies.Application.Mappers;
using Movies.Application.Responses;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.CommandHandlers
{
    public class CreateActorMovieHandler : IRequestHandler<CreateActorMovieCommand, MovieDetailsResponse>
    {
        private readonly IRelationRepository _relationRepository;
        private readonly IMovieRepository _movieRepository;

        public CreateActorMovieHandler(IRelationRepository relationRepository, IMovieRepository movieRepository)
        {
            _relationRepository = relationRepository;
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailsResponse> Handle(CreateActorMovieCommand request, CancellationToken cancellationToken)
        {
            var actorMovieEntity = ActorMovieMapper.Mapper.Map<ActorMovie>(request);
            var newActorMovie = await _relationRepository.AddAsync(actorMovieEntity);
            var movieEntity = await _movieRepository.GetFullDataMovie(newActorMovie.MovieId);
            var movieResponse = MovieMapper.Mapper.Map<MovieDetailsResponse>(movieEntity);
            return movieResponse;
        }
    }
}

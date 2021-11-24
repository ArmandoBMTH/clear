using MediatR;
using Movies.Application.Commands;
using Movies.Application.Mappers;
using Movies.Application.Responses;
using Movies.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.CommandHandlers
{
    public class DeleteActorMovieHandler : IRequestHandler<DeleteActorMovieCommand, MovieDetailsResponse>
    {
        private readonly IRelationRepository _relationRepository;
        private readonly IMovieRepository _movieRepository;

        public DeleteActorMovieHandler(IRelationRepository relationRepository, IMovieRepository movieRepository)
        {
            _relationRepository = relationRepository;
            _movieRepository = movieRepository;
        }

        public async Task<MovieDetailsResponse> Handle(DeleteActorMovieCommand request, CancellationToken cancellationToken)
        {
            await _relationRepository.DeleteRelationByMovieIdAndActorName(request.MovieId, request.ActorName);
            var movieEntity = await _movieRepository.GetFullDataMovie(request.MovieId);
            var movieResponse = MovieMapper.Mapper.Map<MovieDetailsResponse>(movieEntity);
            return movieResponse;
        }
    }
}

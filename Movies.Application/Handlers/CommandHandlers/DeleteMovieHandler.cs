using MediatR;
using Movies.Application.Commands;
using Movies.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.CommandHandlers
{
    public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteMovieHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEntity = await _movieRepository.GetByIdAsync(request.Id);
            await _movieRepository.DeleteAsync(movieEntity);
            return Unit.Value;
        }
    }
}

using MediatR;
using Movies.Application.Commands;
using Movies.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.CommandHandlers
{
    public class DeleteActorHandler : IRequestHandler<DeleteActorCommand>
    {
        private readonly IActorRepository _actorRepository;

        public DeleteActorHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<Unit> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var actorEntity = await _actorRepository.GetByIdAsync(request.Id);
            await _actorRepository.DeleteAsync(actorEntity);
            return Unit.Value;
        }
    }
}

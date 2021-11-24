using MediatR;
using Movies.Application.Commands;
using Movies.Application.Mappers;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.CommandHandlers
{
    public class UpdateActorHandler : IRequestHandler<UpdateActorCommand, Actor>
    {
        private readonly IActorRepository _actorRepository;

        public UpdateActorHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<Actor> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            var actorEntity = ActorMapper.Mapper.Map<Actor>(request);
            if (actorEntity is null)
            {
                throw new ApplicationException("Cound't execute mapper");
            }

            var updateActor = await _actorRepository.UpdateAsync(actorEntity);
            return updateActor;
        }
    }
}

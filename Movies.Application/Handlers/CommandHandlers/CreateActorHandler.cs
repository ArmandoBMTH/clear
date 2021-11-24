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
    public class CreateActorHandler : IRequestHandler<CreateActorCommand, ActorResponse>
    {
        private readonly IActorRepository _actorRepository;

        public CreateActorHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<ActorResponse> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            var actorEntity = ActorMapper.Mapper.Map<Actor>(request);
            if (actorEntity is null)
            {
                throw new ApplicationException("Cound't execute mapper");
            }

            var newActor = await _actorRepository.AddAsync(actorEntity);
            var actorResponse = ActorMapper.Mapper.Map<ActorResponse>(newActor);
            return actorResponse;
        }
    }
}

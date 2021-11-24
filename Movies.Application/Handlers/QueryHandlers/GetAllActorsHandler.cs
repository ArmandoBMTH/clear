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
    public class GetAllActorsHandler : IRequestHandler<GetAllActorsQuery, IEnumerable<ActorResponse>>
    {
        private readonly IActorRepository _actorRepository;

        public GetAllActorsHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<IEnumerable<ActorResponse>> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
        {
            var actorsEntity = await _actorRepository.GetAllAsync();
            var actorsResponse = ActorMapper.Mapper.Map<IEnumerable<ActorResponse>>(actorsEntity);
            return actorsResponse;
        }
    }
}

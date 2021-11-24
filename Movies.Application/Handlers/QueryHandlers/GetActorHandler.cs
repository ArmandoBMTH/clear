using MediatR;
using Movies.Application.Mappers;
using Movies.Application.Queries;
using Movies.Application.Responses;
using Movies.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Movies.Application.Handlers.QueryHandlers
{
    public class GetActorHandler : IRequestHandler<GetActorQuery, ActorDetailsResponse>
    {
        private readonly IActorRepository _actorRepository;

        public GetActorHandler(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<ActorDetailsResponse> Handle(GetActorQuery request, CancellationToken cancellationToken)
        {
            var actorEntity = await _actorRepository.GetByIdAsync(request.Id);
            var actorResponse = ActorMapper.Mapper.Map<ActorDetailsResponse>(actorEntity);
            return actorResponse;
        }
    }
}

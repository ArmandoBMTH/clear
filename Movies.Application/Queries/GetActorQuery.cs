using MediatR;
using Movies.Application.Responses;
using Movies.Core.Entities;

namespace Movies.Application.Queries
{
    public class GetActorQuery : IRequest<ActorDetailsResponse>
    {
        public int Id { get; set; }
    }
}

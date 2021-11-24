using MediatR;

namespace Movies.Application.Commands
{
    public class DeleteActorCommand : IRequest
    {
        public int Id { get; set; }
    }
}

using MediatR;
using Movies.Application.Responses;
using System;

namespace Movies.Application.Commands
{
    public class CreateActorCommand : IRequest<ActorResponse>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

using MediatR;
using Movies.Core.Entities;
using System;

namespace Movies.Application.Commands
{
    public class UpdateActorCommand : IRequest<Actor>
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

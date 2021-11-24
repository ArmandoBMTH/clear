using System;

namespace Movies.Application.Responses
{
    public class ActorDetailsResponse
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

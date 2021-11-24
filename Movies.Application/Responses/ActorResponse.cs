using System;

namespace Movies.Application.Responses
{
    public class ActorResponse
    {
        public int ActorId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Date
        {
            get
            {
                return DateOfBirth.ToString("dddd, dd MMMM yyyy");
            }
        }
    }
}

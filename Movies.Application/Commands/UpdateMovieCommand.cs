using MediatR;
using Movies.Application.Responses;
using System;

namespace Movies.Application.Commands
{
    public class UpdateMovieCommand : IRequest<MovieReponse>
    {
        public string Title { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

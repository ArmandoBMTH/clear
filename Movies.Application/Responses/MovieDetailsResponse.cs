using System;
using System.Collections.Generic;

namespace Movies.Application.Responses
{
    public class MovieDetailsResponse
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<string> Actors { get; set; }
    }
}

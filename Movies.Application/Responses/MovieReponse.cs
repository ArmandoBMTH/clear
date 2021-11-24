using System;

namespace Movies.Application.Responses
{
    public class MovieReponse
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Date
        {
            get
            {
                return ReleaseDate.ToString("dddd, dd MMMM yyyy");
            }
        }
    }
}

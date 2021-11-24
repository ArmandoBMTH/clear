using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Core.Entities
{
    //We defined som annotations to restrict colums in database
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [StringLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string Title { get; set; }
        [StringLength(100, ErrorMessage = "Cannot exceed 100 characters")]
        public string Country { get; set; }
        [StringLength(100, ErrorMessage = "Cannot exceed 100 characters")]
        public string Gender { get; set; }
        [StringLength(1000, ErrorMessage = "Cannot exceed 1000 characters")]
        public string ImageUrl { get; set; }
        [Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
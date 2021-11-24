using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Core.Entities
{
    //We defined som annotations to restrict colums in database
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        [StringLength(255, ErrorMessage = "Cannot exceed 255 characters")]
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
    }
}

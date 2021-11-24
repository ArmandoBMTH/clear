using System.ComponentModel.DataAnnotations;

namespace Movies.Core.Entities
{
    public class ActorMovie
    {
        [Key]
        public int ActorMovieId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}

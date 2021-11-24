using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;

namespace Movies.Infrastructure.Data
{
    public class MoviesContext : DbContext
    {
        //We defined the tables that will be map
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //In this seccion we defined table names in SQL
            builder.Entity<Movie>().ToTable("Movies");
            builder.Entity<Actor>().ToTable("Actors");
            builder.Entity<ActorMovie>().ToTable("ActorMovies");

            //In this seccion we defined some restrictions
            builder.Entity<Movie>().HasIndex(m => m.Title).IsUnique();
            //We created a unique index to not allow repeat relations
            builder.Entity<ActorMovie>().HasIndex(am => new { am.ActorId, am.MovieId }).IsUnique();
        }

    }
}

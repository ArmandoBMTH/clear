using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using Movies.Infrastructure.Data;
using Movies.Infrastructure.Repositories.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Repositories
{
    public class ActorRepository : Repository<Actor>, IActorRepository
    {
        public ActorRepository(MoviesContext moviesContext) : base(moviesContext)
        {

        }

        public async Task<IEnumerable<Movie>> GetMoviesByActor(int id)
        {
            //get all movies by actor
            return await _moviesContext.Movies.Include(m => m.ActorMovies).Where(mo => mo.ActorMovies.Any(rel => rel.ActorId == id)).ToListAsync();
        }
    }
}
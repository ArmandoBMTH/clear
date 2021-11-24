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
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MoviesContext moviesContext) : base(moviesContext) 
        {
            
        }

        public async Task<Movie> GetFullDataMovie(int id)
        {
            //get all full data relation by movie
            return await _moviesContext.Movies.Include(m => m.ActorMovies).ThenInclude(am => am.Actor).FirstOrDefaultAsync(mo => mo.MovieId == id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesBySomeTextAsync(string text)
        {
            //get some movies by searching...
            return await _moviesContext.Movies.Include(m => m.ActorMovies).ThenInclude(am => am.Actor).Where(mo => mo.Title.Contains(text) || mo.Gender.Contains(text) || mo.ActorMovies.Any(rel => rel.Actor.Name.Contains(text))).ToListAsync();
        }
    }
}

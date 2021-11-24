using Microsoft.EntityFrameworkCore;
using Movies.Core.Entities;
using Movies.Core.Repositories;
using Movies.Infrastructure.Data;
using Movies.Infrastructure.Repositories.Base;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Repositories
{
    public class RelationRepository : Repository<ActorMovie>, IRelationRepository
    {
        public RelationRepository(MoviesContext movieContext) : base(movieContext)
        {

        }

        public async Task DeleteRelationByMovieIdAndActorName(int id, string actorName)
        {
            //Delete relation searching by idmovie and actorname
            var actorMovie = await _moviesContext.ActorMovies.Include(am => am.Actor).FirstOrDefaultAsync(rel => rel.MovieId == id && rel.Actor.Name == actorName);
            _moviesContext.Remove(actorMovie);
            await _moviesContext.SaveChangesAsync();
        }
    }
}

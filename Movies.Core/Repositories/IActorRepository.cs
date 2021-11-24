using Movies.Core.Entities;
using Movies.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Core.Repositories
{
    public interface IActorRepository : IRepository<Actor>
    {
        Task<IEnumerable<Movie>> GetMoviesByActor(int id);
    }
}

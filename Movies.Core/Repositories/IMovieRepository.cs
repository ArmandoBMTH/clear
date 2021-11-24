using Movies.Core.Entities;
using Movies.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetMoviesBySomeTextAsync(string text);
        Task<Movie> GetFullDataMovie(int id);
    }
}

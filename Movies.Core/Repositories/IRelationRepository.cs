using Movies.Core.Entities;
using Movies.Core.Repositories.Base;
using System.Threading.Tasks;

namespace Movies.Core.Repositories
{
    public interface IRelationRepository : IRepository<ActorMovie>
    {
        Task DeleteRelationByMovieIdAndActorName(int id, string actorName);
    }
}

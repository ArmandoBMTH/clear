using Microsoft.EntityFrameworkCore;
using Movies.Core.Repositories.Base;
using Movies.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MoviesContext _moviesContext;

        public Repository(MoviesContext moviesContext)
        {
            _moviesContext = moviesContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _moviesContext.Set<T>().AddAsync(entity);
            await _moviesContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _moviesContext.Set<T>().Remove(entity);
            await _moviesContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _moviesContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _moviesContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _moviesContext.Set<T>().Update(entity);
            await _moviesContext.SaveChangesAsync();
            return entity;
        }
    }
}

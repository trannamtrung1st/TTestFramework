using TTestFramework.Core.Entities;
using TTestFramework.Core.Interfaces;

namespace TTestFramework.Core.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly MainDbContext _dbContext;

        public GenericRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(T entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public Task Delete(T entity)
        {
            _dbContext.Remove(entity);

            return Task.CompletedTask;
        }

        public async Task<T> Find(params object[] keys)
        {
            var entity = await _dbContext.Set<T>().FindAsync(keys);

            return entity;
        }

        public IQueryable<T> Query()
        {
            return _dbContext.Set<T>();
        }

        public Task Update(T entity)
        {
            _dbContext.Update(entity);

            return Task.CompletedTask;
        }
    }
}

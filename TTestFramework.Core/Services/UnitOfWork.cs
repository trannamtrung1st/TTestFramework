using TTestFramework.Core.Entities;
using TTestFramework.Core.Interfaces;

namespace TTestFramework.Core.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainDbContext _dbContext;

        public UnitOfWork(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

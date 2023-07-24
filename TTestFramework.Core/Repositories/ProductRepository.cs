using TTestFramework.Core.Entities;
using TTestFramework.Core.Interfaces;

namespace TTestFramework.Core.Repositories
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
    }

    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(MainDbContext dbContext) : base(dbContext)
        {
        }
    }
}

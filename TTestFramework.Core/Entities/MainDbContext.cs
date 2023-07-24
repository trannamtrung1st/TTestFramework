using Microsoft.EntityFrameworkCore;

namespace TTestFramework.Core.Entities
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MainDbContext()
        {
        }

        public virtual DbSet<ProductEntity> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(nameof(TTestFramework));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(builder =>
            {
                builder.HasKey(e => e.Name);
            });
        }
    }
}

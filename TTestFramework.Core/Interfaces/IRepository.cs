namespace TTestFramework.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query();
        Task<T> Find(params object[] keys);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}

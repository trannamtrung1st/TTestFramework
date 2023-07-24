namespace TTestFramework.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitChanges();
    }
}

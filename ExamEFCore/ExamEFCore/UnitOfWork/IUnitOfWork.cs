namespace ExamEFCore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitTransaction();
        Task RollbackTransactionAsync();
        Task SaveChangesAsync();
    }
}

using ExamEFCore.Models;
using System.Linq.Expressions;

namespace ExamEFCore.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task Add(T entity);
        Task Update(T entity);
        void Delete(T entity);
        void BulkDelete(IEnumerable<T> entities);
        void BulkInsert(IEnumerable<T> entities);

    }
}

using ExamEFCore.Models;

namespace ExamEFCore.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> getFullInForAllProduct();
        Task<Product> GetProductByNameAsync(string productName);
    }
}

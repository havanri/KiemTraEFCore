using ExamEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamEFCore.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> getFullInForAllProduct()
        {
            var listProduct =  _context.Products.Include(p=>p.ProductImages).ThenInclude(i=>i.Image).Include(p=>p.Category).ToList();
            return listProduct;
        }

        public async Task<Product> GetProductByNameAsync(string productName)
        {
            var result = await _context.Products.Include(p => p.ProductImages).ThenInclude(i => i.Image).Include(p => p.Category).
                FirstOrDefaultAsync(p => p.Name == productName);
            return result;
        }
    }
}

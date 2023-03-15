using ExamEFCore.DTOs.Product;
using ExamEFCore.Models;

namespace ExamEFCore.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> getFullInForAllProduct();
        Task<IEnumerable<Product>> getAll();
        Task<bool> CreateProductAsync(CreateProductDto createProductDto);
        Task<bool> isExistCategory(int categoryId);
        Task<bool> UpdateProductAsync(int id, UpdateProductDto updateProductDto);
    }
}

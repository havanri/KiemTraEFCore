using ExamEFCore.Models;

namespace ExamEFCore.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
    }
}

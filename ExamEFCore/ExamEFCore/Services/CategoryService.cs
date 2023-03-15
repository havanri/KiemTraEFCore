using ExamEFCore.Models;
using ExamEFCore.Repositories;
using ExamEFCore.UnitOfWork;

namespace ExamEFCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepo)
        {
            _unitOfWork = unitOfWork;
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _categoryRepo.GetAll();
            return categories;
        }
    }
}

using AutoMapper;
using ExamEFCore.DTOs.Product;
using ExamEFCore.Models;
using ExamEFCore.Repositories;
using ExamEFCore.UnitOfWork;

namespace ExamEFCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository, ICategoryRepository categoryRepo,IMapper mapper)
        {
            _productRepo = productRepository;
            _categoryRepo = categoryRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> getFullInForAllProduct()
        {
            var products = await _productRepo.getFullInForAllProduct();
            return products;
        }
        public async Task<bool> isExistCategory(int categoryId)
        {
            var category = await _categoryRepo.GetById(categoryId);
            if (category == null)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> CreateProductAsync(CreateProductDto createProductDto)
        {
            /*_unitOfWork.BeginTransactionAsync();*/
            try
            {
                // Kiểm tra xem sản phẩm có tồn tại chưa
                var product = await _productRepo.GetProductByNameAsync(createProductDto.Name);
                if (product != null)
                {
                    throw new Exception($"Product {createProductDto.Name} already exists");
                }

                // Tạo mới sản phẩm
                product = _mapper.Map<CreateProductDto, Product>(createProductDto);

                await _productRepo.Add(product);
                _unitOfWork.SaveChangesAsync();
                /*await _unitOfWork.SaveChangesAsync();*/

                /*await _unitOfWork.CommitTransaction();*/
                return true;
            }
            catch (Exception ex)
            {
                /*await _unitOfWork.RollbackTransactionAsync();*/
                throw;
            }
        }

        public async Task<IEnumerable<Product>> getAll()
        {
            var products = await _productRepo.GetAll();
            return products;
        }

        public async Task<bool> UpdateProductAsync(int productId, UpdateProductDto updateProductDto)
        {
            try
            {
                var product = await _productRepo.GetById(productId);

                if (product == null)
                {
                    throw new ArgumentException("Product not found");
                }
                product = _mapper.Map<UpdateProductDto, Product>(updateProductDto);
                product.Id = productId;
                product.DateUpdated = DateTime.Now;
                await _productRepo.Update(product);
                var productTest = _productRepo.GetById(productId);

                /*_unitOfWork.CommitTransaction();*/
                /*_unitOfWork.SaveChangesAsync();*/
                return true;
            }
            catch (Exception ex)
            {
/*                _unitOfWork.RollbackTransactionAsync();*/
                // Handle exception here
                throw new Exception($"Unable to create new category: {ex.Message}");
            }
        }
    }
}

using ExamEFCore.DTOs.Product;
using ExamEFCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamEFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.getAll();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateProductDto createProductDto)
        {
            if (string.IsNullOrEmpty(createProductDto.Name))
            {
                return BadRequest("Product name cannot be empty");
            }

            // Check if product price is negative
            if (createProductDto.Price < 0)
            {
                return BadRequest("Product price cannot be negative");
            }

            // Check if product category is valid
            var category = await _productService.isExistCategory(createProductDto.CategoryId);
            if (category == false)
            {
                return BadRequest("Invalid product category");
            }
            var result = await _productService.CreateProductAsync(createProductDto);
            if (result)
            {
                return Ok("Product created successfully");
            }
            else
            {
                return BadRequest("Failed to create product.");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto productdto)
        {
            var result = await _productService.UpdateProductAsync(id, productdto);
            return Ok(result);
        }
    }
}

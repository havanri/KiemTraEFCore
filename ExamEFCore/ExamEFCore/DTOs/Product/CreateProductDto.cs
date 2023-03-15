namespace ExamEFCore.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }
        public bool Continue { get; set; }
        public int CategoryId { get; set; }
    }
}

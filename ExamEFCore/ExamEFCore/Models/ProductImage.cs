using System.ComponentModel.DataAnnotations.Schema;

namespace ExamEFCore.Models
{
    [Table("Product_image")]
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int ImageId { get; set; }
        public Image? Image { get; set; }

    }
}

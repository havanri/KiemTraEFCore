using System.ComponentModel.DataAnnotations;

namespace ExamEFCore.Models
{
    public class Image : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public List<ProductImage>? ProductImages { get; set; }
    }
}

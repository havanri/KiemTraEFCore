using System.ComponentModel.DataAnnotations;

namespace ExamEFCore.Models
{
    public class Category : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product>? Products { get; set; }

    }
}

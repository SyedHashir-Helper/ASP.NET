using System.ComponentModel.DataAnnotations;

namespace FirstAppNet.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
		[Display(Name = "Category Name")]
		public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Product>? Products { get; set; }
		public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
	}
}

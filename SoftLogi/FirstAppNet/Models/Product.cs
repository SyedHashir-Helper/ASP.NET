using System.ComponentModel.DataAnnotations;

namespace FirstAppNet.Models
{
	public class Product
	{
		public int ProductId { get; set; }

		[Required]
		[Display(Name = "Category")]
		public int? CategoryId { get; set; }

		[Required]
		[Display(Name = "Product Name")]
		public string Name { get; set; } = string.Empty;

		[Required]
		[Range(0, int.MaxValue)]
		public int? Quantity { get; set; }

		[Required]
		[Range(0, double.MaxValue)]
		public double? Price { get; set; }

		[Display(Name = "Tags")]
		public string Tags { get; set; } = string.Empty; // Comma-separated tags

		public Category? Category { get; set; }

		public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
	}
}

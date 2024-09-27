using System.ComponentModel.DataAnnotations.Schema;

namespace FirstAppNet.Models
{
	public class ProductCategory
	{
		[ForeignKey("Product")]
		public int ProductId { get; set; }

		[ForeignKey("Category")]
		public int CategoryId { get; set; }

		public virtual Product? Product { get; set; }
		public virtual Category? Category { get; set; }
	}
}

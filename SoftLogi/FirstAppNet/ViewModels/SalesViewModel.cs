using FirstAppNet.Models;
using FirstAppNet.ViewModels.Validations;
using System.ComponentModel.DataAnnotations;

namespace FirstAppNet.ViewModels
{
	public class SalesViewModel
	{
		public int SelectedCategoryId { get; set; }
		public IEnumerable<Category> Categories { get; set; } = new List<Category>();
		public int SelectedProductId { get; set; }

		[Display(Name="Quantity")]
		[Required]
		[Range(1, int.MaxValue)]
		[SalesViewModel_EnsureProperQuantity]
		public int QuantityToSell { get; set; }
	}
}

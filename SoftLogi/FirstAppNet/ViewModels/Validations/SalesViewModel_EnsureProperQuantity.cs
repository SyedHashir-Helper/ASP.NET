using FirstAppNet.Interfaces;
using FirstAppNet.Models;
using System.ComponentModel.DataAnnotations;

namespace FirstAppNet.ViewModels.Validations
{
	public class SalesViewModel_EnsureProperQuantity : ValidationAttribute
	{

		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var salesViewModel = validationContext.ObjectInstance as SalesViewModel;
			if (salesViewModel != null)
			{
				if (salesViewModel.QuantityToSell <= 0)
				{
					return new ValidationResult("The Quantity has to be sold greater than zero");
				}
				else
				{
					var ProductRepository = validationContext.GetService(typeof(IProductRepository)) as IProductRepository;
					if (ProductRepository != null)
					{
						var product = ProductRepository.GetProductById(salesViewModel.SelectedProductId, loadCategory: false);
						if (product != null)
						{
							if (product.Quantity < salesViewModel.QuantityToSell)
							{
								return new ValidationResult($"The product {product.Name} has only {product.Quantity} items left");
							}
						}
					}
				}
			}
			return ValidationResult.Success;
		}
	}
}

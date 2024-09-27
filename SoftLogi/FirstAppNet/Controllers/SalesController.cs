using FirstAppNet.Database;
using FirstAppNet.Interfaces;
using FirstAppNet.Models;
using FirstAppNet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstAppNet.Controllers
{
	public class SalesController : Controller
	{
		private readonly MarketDBContext marketDB;

		public SalesController(MarketDBContext marketDB, ICategoryRepository categoryRepository, IProductRepository productRepository, 
			ITransactionRepository transactionRepository)
        {
			this.marketDB = marketDB;
			CategoryRepository = categoryRepository;
			ProductRepository = productRepository;
			TransactionRepository = transactionRepository;
		}

		public ICategoryRepository CategoryRepository { get; }
		public IProductRepository ProductRepository { get; }
		public ITransactionRepository TransactionRepository { get; }

		public IActionResult Index()
		{
			var salesViewModel = new SalesViewModel()
			{
				Categories = CategoryRepository.GetCategories()
			};
			return View(salesViewModel);
		}
		public IActionResult Sell(SalesViewModel salesViewModel)
		{
			if (ModelState.IsValid)
			{
				var prod = ProductRepository.GetProductById(salesViewModel.SelectedProductId, loadCategory: false);
				if (prod != null)
				{
					TransactionRepository.Add(
						"Cashier1",
						salesViewModel.SelectedProductId,
						prod.Name,
						prod.Price.HasValue ? prod.Price.Value : 0,
						prod.Quantity.HasValue ? prod.Quantity.Value : 0,
						salesViewModel.QuantityToSell
					);
					prod.Quantity -= salesViewModel.QuantityToSell;
					ProductRepository.UpdateProduct(salesViewModel.SelectedProductId, prod);
				}
			}
			var product = ProductRepository.GetProductById(salesViewModel.SelectedProductId, loadCategory: false);
			salesViewModel.SelectedCategoryId = product.CategoryId == null ? 0 : product.CategoryId.Value;
			salesViewModel.Categories = CategoryRepository.GetCategories();
			return View("Index", salesViewModel);
		}
	}
}

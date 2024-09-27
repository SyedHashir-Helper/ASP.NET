using FirstAppNet.Database;
using FirstAppNet.Interfaces;
using FirstAppNet.Models;
using FirstAppNet.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace FirstAppNet.Controllers
{
	public class ProductsController : Controller
	{
		private MarketDBContext marketDB;

		public IProductRepository ProductRepository { get; }
		public ICategoryRepository CategoryRepository { get; }

		public ProductsController(MarketDBContext marketDB, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
			this.marketDB = marketDB;
			ProductRepository = productRepository;
			CategoryRepository = categoryRepository;
		}
        public IActionResult Index(string SearchQuery)
		{
			var searchProductViewModel = new ProductSearchViewModel();
			if (SearchQuery != "")
			{
				searchProductViewModel.SearchQuery = SearchQuery;
			}
			var _products = ProductRepository.GetProducts(loadCategory: true, query: SearchQuery);
			searchProductViewModel.Products = _products;
			return View(searchProductViewModel);
		}
		public IActionResult Add()
		{
			ViewBag.Action = "add";
			var productViewModel = new ProductViewModel()
			{
				categories = CategoryRepository.GetCategories()
			};
			return View(productViewModel);
		}
		[HttpPost]
		public IActionResult Add(ProductViewModel productViewModel)
		{
			if (ModelState.IsValid)
			{
				ProductRepository.AddProduct(productViewModel.product);
				return RedirectToAction("Index");
			}
			ViewBag.Action = "add";
			productViewModel.categories = CategoryRepository.GetCategories();
			return View(productViewModel);
		}
		public IActionResult Edit([FromRoute]int id)
		{
			ViewBag.Action = "edit";
			var productViewModel = new ProductViewModel()
			{
				product = ProductRepository.GetProductById(id, loadCategory: true)??new Product(),
				categories = CategoryRepository.GetCategories()
			};
			return View(productViewModel);
		}
		[HttpPost]
		public IActionResult Edit(ProductViewModel productViewModel)
		{
			if (ModelState.IsValid)
			{
				ProductRepository.UpdateProduct(productViewModel.product.ProductId, productViewModel.product);
				return RedirectToAction("Index");
			}
			ViewBag.Action = "edit";
			productViewModel.categories = CategoryRepository.GetCategories();
			return View(productViewModel);
		}

		public IActionResult Delete(int id)
		{
			ProductRepository.DeleteProduct(id);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult GetProductListByCategoryPartial(int categoryId)
		{
			var products = ProductRepository.GetProductsByCategoryId(categoryId);
			return PartialView("_Products", products);
		}
		public IActionResult GetProductByIdPartial(int productId)
		{
			var product = ProductRepository.GetProductById(productId, loadCategory: false);
			return PartialView("_ProductDetail", product);
		}
	}
}

using FirstAppNet.Database;
using FirstAppNet.Datastore.SQL.Repository;
using FirstAppNet.Interfaces;
using FirstAppNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAppNet.Controllers
{
    public class CategoriesController : Controller
    {
		private readonly MarketDBContext marketDB;

		public ICategoryRepository CategoryRepository { get; }

		public CategoriesController(MarketDBContext marketDB, ICategoryRepository categoryRepository)
        {
			this.marketDB = marketDB;
            CategoryRepository = categoryRepository;

		}
        public IActionResult Index()
        {
            var categories = CategoryRepository.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Edit([FromRoute]int? id)
        {
            ViewBag.Action = "edit";
            var category = CategoryRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
				CategoryRepository.UpdateCategory(category.CategoryId, category);

                return RedirectToAction(nameof(Index));
            }
			ViewBag.Action = "edit";
			return View(category);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View(new Category());
        }
        [HttpPost]
        public IActionResult Add([FromForm]Category category)
        {
            if (ModelState.IsValid)
            {
				CategoryRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
			ViewBag.Action = "add";
			return View(category);
        }

        public IActionResult Delete(int categoryId)
        {
			CategoryRepository.DeleteCategory(categoryId);
            return RedirectToAction(nameof(Index));
        }
    }
}

using FirstAppNet.Database;
using FirstAppNet.Interfaces;
using FirstAppNet.Models;

namespace FirstAppNet.Datastore.SQL.Repository
{
	public class Category_SQL : ICategoryRepository
	{
        public Category_SQL(MarketDBContext marketDB)
        {
			MarketDB = marketDB;
		}

		public MarketDBContext MarketDB { get; }

		public void AddCategory(Category category)
		{
			MarketDB.Categories.Add(category);
			MarketDB.SaveChanges();
		}

		public void DeleteCategory(int categoryId)
		{
			var category = MarketDB.Categories.Find(categoryId);
			if (category == null) return;

			MarketDB.Categories.Remove(category);
			MarketDB.SaveChanges();
		}

		public IEnumerable<Category> GetCategories()
		{
			return MarketDB.Categories.ToList();
		}

		public Category GetCategoryById(int categoryId)
		{
			var category = MarketDB.Categories.Find(categoryId);
			if (category == null)
			{
				return new Category();
			}
			return category;
		}

		public void UpdateCategory(int categoryId, Category category)
		{
			if (category.CategoryId != categoryId) return;
			var categoryToUpdate = MarketDB.Categories.Find(categoryId);
			if (categoryToUpdate != null)
			{
				categoryToUpdate.Name = category.Name;
				categoryToUpdate.Description = category.Description;
				MarketDB.SaveChanges();
			}
		}
	}
}

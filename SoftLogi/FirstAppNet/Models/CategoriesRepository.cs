using FirstAppNet.Database;
using System.Net.NetworkInformation;

namespace FirstAppNet.Models
{
	public class CategoriesRepository
	{
		public static MarketDBContext marketDB;
		public static void AddCategory(Category category)
		{
			marketDB.Categories.Add(category);
			marketDB.SaveChanges();
			//var max = _categories.Max(x => x.CategoryId);
			//category.CategoryId = max+1;
			//_categories.Add(category);
		}
		public static List<Category> GetCategories(MarketDBContext marketDB)
		{
			return marketDB.Categories.ToList();
		}

		public static Category GetCategoryById(int categoryId)
		{
			var category = marketDB.Categories.Find(categoryId);
			if (category == null)
			{
				return new Category();
			}
			return category;
		}

		public static void UpdateCategory(int categoryId, Category category)
		{
			if (category.CategoryId != categoryId) return;
			var categoryToUpdate = marketDB.Categories.Find(categoryId);
			if (categoryToUpdate!= null)
			{
				categoryToUpdate.Name = category.Name;
				categoryToUpdate.Description = category.Description;
				marketDB.SaveChanges();
			}
		}
		public static void DeleteCategory(int categoryId)
		{
			var category = marketDB.Categories.Find(categoryId);
			if (category == null) return;

			marketDB.Categories.Remove(category);
			marketDB.SaveChanges();
			//var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
			//if (category != null)
			//{
			//	_categories.Remove(category);
			//}
		}
	}
}

using FirstAppNet.Models;

namespace FirstAppNet.Interfaces
{
	public interface ICategoryRepository
	{
		public IEnumerable<Category> GetCategories();
		public void AddCategory(Category category);
		public Category GetCategoryById(int categoryId);
		public void UpdateCategory(int categoryId, Category category);
		public void DeleteCategory(int categoryId);
	}
}

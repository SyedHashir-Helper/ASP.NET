using FirstAppNet.Models;

namespace FirstAppNet.Interfaces
{
	public interface IProductRepository
	{
		public void AddProduct(Product product);

		public List<Product>? GetProducts(bool loadCategory, string query = "");

		public Product? GetProductById(int productId, bool loadCategory = false);

		public void UpdateProduct(int productId, Product product);
		public List<Product> GetProductsByCategoryId(int categoryId);

		public void DeleteProduct(int productId);
	}
}

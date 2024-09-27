using FirstAppNet.Database;
using Microsoft.EntityFrameworkCore;

namespace FirstAppNet.Models
{
	public class ProductRepository
	{
		public static MarketDBContext MarketDB { get; set; }
		public ProductRepository(MarketDBContext marketDB)
		{
			MarketDB = marketDB;
		}
		private static List<Product> _products = new List<Product>()
		{
			new Product { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99 },
			new Product { ProductId = 2, CategoryId = 1, Name = "Canada Dry", Quantity = 200, Price = 1.99 },
			new Product { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 300, Price = 1.50 },
			new Product { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 300, Price = 1.50 }
		};


		public static void AddProduct(Product product)
		{
			MarketDB.Products.Add(product);
			MarketDB.SaveChanges();
		}

		public static List<Product>? GetProducts(bool loadCategory)
		{
			if (loadCategory) return MarketDB.Products.Include(x => x.Category).OrderBy(x => x.CategoryId).ToList();
			return MarketDB.Products.ToList();
		}

		public static Product? GetProductById(int productId, bool loadCategory = false)
		{
			if (loadCategory)
			{
				return MarketDB.Products.Include(x => x.Category).FirstOrDefault(x => x.ProductId == productId);
			}
			else
			{
				return MarketDB.Products.FirstOrDefault(x => x.ProductId == productId);
			}
		}

		public static void UpdateProduct(int productId, Product product)
		{
			if (productId != product.ProductId) return;

			var productToUpdate = MarketDB.Products.Find(productId);
			if (productToUpdate != null)
			{
				productToUpdate.Name = product.Name;
				productToUpdate.Quantity = product.Quantity;
				productToUpdate.Price = product.Price;
				productToUpdate.CategoryId = product.CategoryId;
				MarketDB.SaveChanges();
			}
		}
		public static List<Product> GetProductsByCategoryId(int categoryId)
		{
			return MarketDB.Products.Where(x => x.CategoryId == categoryId).ToList();
		}

		public static void DeleteProduct(int productId)
		{
			var product = MarketDB.Products.Find(productId);
			if (product != null)
			{
				MarketDB.Products.Remove(product);
				MarketDB.SaveChanges();
			}
		}
	}
}

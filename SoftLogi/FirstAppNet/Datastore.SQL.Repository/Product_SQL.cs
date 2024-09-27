using FirstAppNet.Database;
using FirstAppNet.Interfaces;
using FirstAppNet.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAppNet.Datastore.SQL.Repository
{
	public class Product_SQL : IProductRepository
	{
        public Product_SQL(MarketDBContext marketDB)
        {
			MarketDB = marketDB;
		}

		public MarketDBContext MarketDB { get; set; }

		public void AddProduct(Product product)
		{
			MarketDB.Products.Add(product);
			MarketDB.SaveChanges();
		}

		public void DeleteProduct(int productId)
		{
			var product = MarketDB.Products.Find(productId);
			if (product != null)
			{
				MarketDB.Products.Remove(product);
				MarketDB.SaveChanges();
			}
		}

		public Product? GetProductById(int productId, bool loadCategory = false)
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

		public List<Product>? GetProducts(bool loadCategory, string query="")
		{
			if (!loadCategory)
			{
				if (query != null && query != "")
				{
					return MarketDB.Products.Where(x => EF.Functions.Like(x.Name, $"%{query}%") || EF.Functions.Like(x.Tags, $"%query%")).ToList();
                }
				return MarketDB.Products.ToList();
			}
			if(query != null && query != "")
			{
				List<Product> set = MarketDB.Products.Include(x => x.Category).OrderBy(x => x.CategoryId).ToList();
                return set.Where(x=>x.Name.Contains(query) ||  x.Tags.Contains(query)).ToList();
            }
			return MarketDB.Products.Include(x => x.Category).OrderBy(x => x.CategoryId).ToList();
        }

		public List<Product> GetProductsByCategoryId(int categoryId)
		{
			return MarketDB.Products.Where(x => x.CategoryId == categoryId).ToList();
		}

		public void UpdateProduct(int productId, Product product)
		{
			if (productId != product.ProductId) return;

			var productToUpdate = MarketDB.Products.Find(productId);
			if (productToUpdate != null)
			{
				productToUpdate.Name = product.Name;
				productToUpdate.Quantity = product.Quantity;
				productToUpdate.Price = product.Price;
				productToUpdate.CategoryId = product.CategoryId;
				productToUpdate.Tags = product.Tags;
				MarketDB.SaveChanges();
			}
		}
	}
}

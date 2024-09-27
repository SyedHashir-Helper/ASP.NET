using FirstAppNet.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAppNet.Database
{
	public class MarketDBContext : DbContext
	{
        public MarketDBContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Transaction> Transactions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Category>()
				.HasMany(c => c.Products)
				.WithOne(p => p.Category)
				.HasForeignKey(p => p.CategoryId);

			modelBuilder.Entity<Category>()
				.HasData(
					new Category { CategoryId = 1, Description = "Bakery Product Item", Name = "Bakery" },
					new Category { CategoryId = 2, Description = "Iron Product Item", Name = "Metal" },
					new Category { CategoryId = 3, Description = "Food Product Item", Name = "Fast Food" }
				);

			modelBuilder.Entity<ProductCategory>()
			.HasKey(pc => new { pc.ProductId, pc.CategoryId });

			modelBuilder.Entity<ProductCategory>()
				.HasOne(pc => pc.Product)
				.WithMany(p => p.ProductCategories)
				.HasForeignKey(pc => pc.ProductId)
				.OnDelete(DeleteBehavior.Restrict); ;

			modelBuilder.Entity<ProductCategory>()
				.HasOne(pc => pc.Category)
				.WithMany(c => c.ProductCategories)
				.HasForeignKey(pc => pc.CategoryId)
				.OnDelete(DeleteBehavior.Restrict); ;
		}

	}
}

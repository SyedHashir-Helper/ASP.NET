using FirstAppNet.Models;

namespace FirstAppNet.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Category> categories { get; set; } = new List<Category>();
        public Product product { get; set; } = new Product();
    }
}

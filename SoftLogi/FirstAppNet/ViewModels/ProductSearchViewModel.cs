using FirstAppNet.Models;

namespace FirstAppNet.ViewModels
{
    public class ProductSearchViewModel
    {

        public string SearchQuery { get; set; } = "";
        public List<Product> Products { get; set; }
    }
}

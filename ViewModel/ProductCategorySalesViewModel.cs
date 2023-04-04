using storeManager.Models;

namespace storeManager.ViewModel
{
	public class ProductCategorySalesViewModel
	{
        public Sales Sales { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }

        public ProductCategorySalesViewModel()
        {
            Categories = new List<Category>();
            Products = new List<Product>();
        }
    }
}

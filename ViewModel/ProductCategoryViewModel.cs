using storeManager.Models;

namespace storeManager.ViewModel
{
    public class ProductCategoryViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }

        public ProductCategoryViewModel()
        {
            Categories = new List<Category>();
        }
    }

}

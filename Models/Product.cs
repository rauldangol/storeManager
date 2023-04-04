using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace storeManager.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int productId { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        public string productCategory { get; set; }
        [Required]
        public int productPrice { get; set; } = 0;
        public int productQuantity { get; set; } = 0;



    }
}

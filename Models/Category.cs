using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace storeManager.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        public string categoryName { get; set; }

        [DisplayName("Category Quantity")]
        [Range(1,10000, ErrorMessage ="Quantity must be between 0 and 10000")]
        public int categoryQuantity { get; set; } = 0;

    }
}

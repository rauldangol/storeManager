using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace storeManager.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Total { get; set; }
    }


}
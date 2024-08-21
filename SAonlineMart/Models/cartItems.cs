using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAonlineMart.Models
{
    public class cartItems
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int customerID { get; set; }
        public Customer customer { get; set; }
        [ForeignKey("Product")]
        public int productID { get; set; }
        public Product product { get; set; } 
        public int quantity { get; set; } = 1;
    }
}

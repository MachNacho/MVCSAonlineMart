using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAonlineMart.Models
{
    public class OrderItems
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}

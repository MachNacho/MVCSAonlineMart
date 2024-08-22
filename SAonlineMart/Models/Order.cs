using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAonlineMart.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
		[ForeignKey("customer")]
		public string? customerID { get; set; }
		public Customer customer { get; set; }
		[DataType(DataType.Date)]
        public DateTime ProdcutUpload { get; set; } = DateTime.Now;
        public ICollection<OrderItems> OrdersItems { get; set; }
    }
}

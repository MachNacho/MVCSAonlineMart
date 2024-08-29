using SAonlineMart.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SAonlineMart.ViewModels
{
    public class OrderViewModel
    {
        public string customerID { get; set; }
		public Order Order { get; set; }
		public DateTime ProdcutUpload { get; set; } 
		public ICollection<OrderItems> OrdersItems { get; set; }
    }
}

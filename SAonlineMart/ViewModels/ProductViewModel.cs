using SAonlineMart.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace SAonlineMart.ViewModels
{
	public class ProductViewModel
	{
		public int id { get; set; }
		public string productName { get; set; }
		public string productDescription { get; set; }
		public ProductCategory productCategory { get; set; }
		public double productPrice { get; set; }
		public string imageURL { get; set; }
	}
}

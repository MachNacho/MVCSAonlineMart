using SAonlineMart.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SAonlineMart.ViewModels
{
    public class OrderViewModel
    {
        [Required(ErrorMessage = "address is required")]
		[Display(Name = "Address")]
		public string address { get; set; }
        [Required(ErrorMessage = "cvv is required")]
		[StringLength(3)]
		[Display(Name = "CVV")]
		public string cvv { get; set; }
        [Required(ErrorMessage = "card number is required")]
		[Display(Name = "Card Number")]
		public string cardNumber { get; set; }
		[Required(ErrorMessage = "exp is required")]
		[Display(Name = "Card Experation Date")]
		[DataType(DataType.Date)]
		public DateOnly expdate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}

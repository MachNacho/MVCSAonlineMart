using System;
using System.ComponentModel.DataAnnotations;

namespace SAonlineMart.ViewModels
{
	public class RegisterViewModel
	{
		[Display(Name = "First name")]
		[Required(ErrorMessage = "first name is required")]
		public string Firstname { get; set; }
		[Display(Name = "Last name")]
		[Required(ErrorMessage = "last name is required")]
		public string Lastname { get; set; }
		[Display(Name = "Birthday")]
		[Required(ErrorMessage = "Your birthday is required")]
		[DataType(DataType.Date)]
		public DateOnly birthday { get; set; } = DateOnly.FromDateTime(DateTime.Now);

		[Display(Name = "Email address")]
		[Required(ErrorMessage ="Email address is required")]
		public string EmailAddress { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Confirm password")]
		[Required(ErrorMessage = "Confirm password is required")]
		[DataType(DataType.Password)]
		[Compare("Password",ErrorMessage ="Password do not match")]
		public string ConfirmPassword { get; set; }
	}
}

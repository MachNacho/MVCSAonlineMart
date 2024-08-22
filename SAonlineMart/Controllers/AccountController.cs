using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SAonlineMart.Data;
using SAonlineMart.Models;
using SAonlineMart.ViewModels;

namespace SAonlineMart.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<Customer> _userManager;
		private readonly SignInManager<Customer> _signInManager;
		private readonly ApplicationDBcontext _context;
		public AccountController(UserManager<Customer> userManager,SignInManager<Customer> signInManager, ApplicationDBcontext context)
		{
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Login()
		{
			var response = new LoginViewModel();
			return View(response);
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if(!ModelState.IsValid) return View(model);

			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user != null) 
			{
				var PasswordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
				if (PasswordCheck)
				{
					var result = await _signInManager.PasswordSignInAsync(user,model.Password,false,false);
					if (result.Succeeded)
					{
						return RedirectToAction("Index","Product");
					}
				}
				TempData["Error"] = "Wrong Credatnials";
				return View(model);
			}
			TempData["Error"] = "Wrong Credatnials";
			return View(model);
		}
	}
}

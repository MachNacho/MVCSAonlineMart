using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public AccountController(UserManager<Customer> userManager, SignInManager<Customer> signInManager, ApplicationDBcontext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()//used for showing page
		{
			var response = new LoginViewModel();
			return View(response);
		}

		[HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)//Used for logging in
		{
			if(!ModelState.IsValid) return View(model);
			var user = await _userManager.FindByEmailAsync(model.EmailAddress);
			if (user != null)
			{
				var PasswordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
				if (PasswordCheck)
				{
					var result = await _signInManager.PasswordSignInAsync(user, model.Password, true,false);
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

		public IActionResult Register() { var response = new RegisterViewModel(); return View(response); }
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model) 
		{
			if (!ModelState.IsValid) return View(model);
			var user = await _userManager.FindByEmailAsync(model.EmailAddress);
			if (user != null) {
				TempData["Error"] = "This email address already in use";
				return View(model);
			}
			var newcustomer = new Customer()
			{
				FirstName = model.Firstname,
				LaststName = model.Lastname,
				birthDay = model.birthday,
				Email = model.EmailAddress,
				UserName = $"{model.Firstname}_{model.Lastname}"
			};
			var newUserResponse = await _userManager.CreateAsync(newcustomer,model.Password);//create user
			if (newUserResponse.Succeeded) { await _userManager.AddToRoleAsync(newcustomer, UserRoles.User); }//add a role
			return RedirectToAction("Login", "Account");
		}

		[HttpGet]
		public async Task<IActionResult> Logout() 
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index","Product");
		}
    }

}

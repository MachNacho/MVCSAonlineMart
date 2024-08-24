using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SAonlineMart.Data;
using SAonlineMart.Models;

namespace SAonlineMart.Controllers
{
    public class CartController : Controller
    {

        private readonly ApplicationDBcontext _context;
        public CartController(ApplicationDBcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = _context.cartitems.Include(a => a.product).ToList().Where(x=>x.customerID == User.Identity.GetUserId());
            return View(cart);
        }

        [HttpPost]
        public IActionResult Add(int productId, int quantity) 
        {
            var CI = _context.cartitems.FirstOrDefault(x => x.customerID == User.Identity.GetUserId() && x.productID == productId);
            if (CI == null) 
            {
                _context.cartitems.Add(new cartItems { customerID = User.Identity.GetUserId(), productID = productId, quantity = quantity });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            cartItems cart = _context.cartitems.FirstOrDefault(c => c.Id == id);
            _context.cartitems.Remove(cart);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //public IActionResult Add(int productID) 
        //{
        //}
    }
}

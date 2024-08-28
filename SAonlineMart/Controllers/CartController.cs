using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SAonlineMart.Data;
using SAonlineMart.Interfaces;
using SAonlineMart.Models;
using SAonlineMart.Repository;


namespace SAonlineMart.Controllers
{
    //TODO: REPOSITORY FOR THIS CONTROLLER
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<cartItems> cartItems = await _cartRepository.GetAll();
            return View(cartItems.Where(x => x.customerID == User.Identity.GetUserId()));
        }

        [HttpPost]
        public IActionResult Add(int productId) 
        {
            _cartRepository.Add(productId, User.Identity.GetUserId());
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MinusOne(int id) //minus one from cart item
        {

            _cartRepository.MinusOne(id);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult PlusOne(int id)//plus one from cart item
        {
            _cartRepository.PlusOne(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Remove(int id)
        {
            _cartRepository.RemoveOne(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult RemoveAll()
        {
            _cartRepository.RemoveALL(User.Identity.GetUserId());
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SAonlineMart.Data;
using SAonlineMart.Interfaces;
using SAonlineMart.Models;
using SAonlineMart.Repository;
using SAonlineMart.ViewModels;


namespace SAonlineMart.Controllers
{
    //TODO: REPOSITORY FOR THIS CONTROLLER
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly ApplicationDBcontext _context;
        public CartController(ICartRepository cartRepository,ApplicationDBcontext context)
        {
            _context = context;
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<cartItems> cartItems = await _cartRepository.GetAll(User.Identity.GetUserId());
            return View(cartItems);
        }

        public IActionResult Checkout() 
        {
            var response = new OrderViewModel();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel viewModel) 
        {
			if (!ModelState.IsValid) return View(viewModel);
			var cartitems = await _cartRepository.GetAll(User.Identity.GetUserId());

			var response = new Order() 
            { 
                customerID = User.Identity.GetUserId(),
                address = viewModel.address,
                cvv = viewModel.cvv,
                expdate = viewModel.expdate,
                cardNumber = viewModel.cardNumber,
                OrdersItems = new List<OrderItems>()
			};
            foreach(var item in cartitems) 
            {
                var orderitems = new OrderItems
                {
                    Name = item.product.productName,
                    Price = item.product.productPrice,
                    Quantity = item.quantity,
                    Order = response           
                };
                response.OrdersItems.Add(orderitems);
            }

			 _context.order.Add(response);
            _cartRepository.CompleteCheckout(response);
            _cartRepository.RemoveALL(cartitems);
			return RedirectToAction("Index","Order");
		}

        //[HttpPost]
       //public async Task<IActionResult> Checkout(OrderViewModel orderViewModel) {  return View(); }


        [HttpPost]
        public IActionResult Add(int productId) 
        {
            if(User.Identity.GetUserId() == null){return RedirectToAction("Login","Account");;}
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
        public async Task<IActionResult> RemoveAll()
        {
            
            _cartRepository.RemoveALL( await _cartRepository.GetAll(User.Identity.GetUserId()));
            return RedirectToAction("Index");
        }
    }
}

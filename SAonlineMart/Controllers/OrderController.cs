using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAonlineMart.Data;
using SAonlineMart.Interfaces;
using SAonlineMart.Models;
using SAonlineMart.Repository;
using System.Collections.Generic;

namespace SAonlineMart.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDBcontext _context;
        private readonly ICartRepository _cartRepository;
        public OrderController( ApplicationDBcontext context, ICartRepository cartRepository) {  _context = context; _cartRepository = cartRepository; }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _context.order.Where(x => x.customerID == User.Identity.GetUserId()).ToListAsync();
            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
			var order = await _context.order.Include(x=>x.OrdersItems).FirstOrDefaultAsync(x => x.Id == id);
			return View(order);
        }
    }
}

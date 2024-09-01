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

        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository) {   _orderRepository = orderRepository; }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderRepository.GetAll(User.Identity.GetUserId());
            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
			var order = await _orderRepository.GetByIdAsync(id);
			return View(order);
        }
    }
}

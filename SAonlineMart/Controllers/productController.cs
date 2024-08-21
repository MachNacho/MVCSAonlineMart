using Microsoft.AspNetCore.Mvc;
using SAonlineMart.Data;
using SAonlineMart.Models;

namespace SAonlineMart.Controllers
{
    public class productController : Controller
    {
        private readonly ApplicationDBcontext _context;
        public productController(ApplicationDBcontext context) { _context = context; }
        public IActionResult Index()
        {
            var products = _context.product.ToList();
            return View(products);
        }

        public IActionResult Details(int id) { 
            Product products = _context.product.FirstOrDefault(c =>c.ID==id);
            return View(products);
        }
    }
}

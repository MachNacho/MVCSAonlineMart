using Microsoft.AspNetCore.Mvc;
using SAonlineMart.Data;
using SAonlineMart.Interfaces;
using SAonlineMart.Models;

namespace SAonlineMart.Controllers
{
    public class productController : Controller
    {
        private readonly IProductRepository _productRepository;
        public productController(IProductRepository productRepository) { _productRepository = productRepository; }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetALL();
            return View(products);
        }

        public async Task<IActionResult> Details(int id) { 
            Product products =await _productRepository.GetByIdAsync(id);
            return View(products);
        }
    }
}

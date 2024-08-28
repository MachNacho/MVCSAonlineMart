using Microsoft.AspNetCore.Mvc;
using SAonlineMart.Interfaces;
using SAonlineMart.Models;

namespace SAonlineMart.Controllers
{
    public class PanelController : Controller
    {
        private readonly IProductRepository _productRepository;
        public PanelController(IProductRepository productRepository) { _productRepository = productRepository; }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetALL();
            return View(products);
        }
    }
}

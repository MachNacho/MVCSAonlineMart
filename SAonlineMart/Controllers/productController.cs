using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SAonlineMart.Data;
using SAonlineMart.Interfaces;
using SAonlineMart.Models;
using SAonlineMart.ViewModels;

namespace SAonlineMart.Controllers
{
    public class productController : Controller
    {

        private readonly IProductRepository _productRepository;
        public productController(IProductRepository productRepository) { _productRepository = productRepository;}
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _productRepository.GetALL();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id) { 
            Product products =await _productRepository.GetByIdAsync(id);
            return View(products);
        }

        public IActionResult Create()
        {
            if (User.IsInRole("admin")) { return View(); }
            return RedirectToAction("Index");           
        }
        [HttpGet]
        public async Task<IActionResult> update(int id)
		{
			Product products = await _productRepository.GetByIdAsync(id);
            var productVM = new ProductViewModel
            {
                id = products.ID,
                productCategory= products.productCategory,
                productDescription=products.productDescription,
                productName=products.productName,
                productPrice=products.productPrice,
                imageURL=products.imageURL
            };
			return View(productVM);
		}
		[HttpPost]
		public async Task<IActionResult> update(ProductViewModel viewModel) 
        {
            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError("", "Failed to edit product");
                return View("update",viewModel); 
            }
            var prod = new Product
            {
                ID = viewModel.id,
                productName = viewModel.productName,
                productPrice=viewModel.productPrice,
                imageURL=viewModel.imageURL,
                productDescription = viewModel.productDescription,
                productCategory=viewModel.productCategory
            };
            _productRepository.Update(prod);
            return RedirectToAction("Index");
        }

		[HttpPost]
        public async Task<IActionResult> Create(Product product) 
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            _productRepository.Add(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete() 
        {
            IEnumerable<Product> products = await _productRepository.GetALL();
            return View(products); 
        }
		[HttpPost]
		public async Task<IActionResult> Delete(int id) 
        {
            Product products = await _productRepository.GetByIdAsync(id);
            _productRepository.Delete(products);
			return RedirectToAction("Delete");
		}
    }
}

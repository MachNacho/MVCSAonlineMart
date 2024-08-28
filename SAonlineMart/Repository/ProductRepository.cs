using Microsoft.EntityFrameworkCore;
using SAonlineMart.Data;
using SAonlineMart.Data.Enum;
using SAonlineMart.Interfaces;
using SAonlineMart.Models;

namespace SAonlineMart.Repository
{
    public class ProductRepository: IProductRepository//implementing the interface
    {
        private readonly ApplicationDBcontext _context;
        public ProductRepository(ApplicationDBcontext context) { _context = context; }//DB
        public async Task<IEnumerable<Product>> GetALL() //retirive all records
        {
            return await _context.product.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetALLbyDate() //retirive all records
        {
            return await _context.product.OrderBy(X=>X.ProdcutUpload).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id) //for details page
        {
            return await _context.product.FirstOrDefaultAsync(c => c.ID == id);
        }
        public async Task<IEnumerable<Product>> GetProductsByCategory(ProductCategory Category)// for filter
        {
            return await _context.product.Where(c => c.productCategory==Category).ToListAsync();
        }

        public bool Add(Product product)
        {
            _context.Add(product);
            return Save();
        }
        public bool Update(Product product)
        {
            _context.Update(product);
            return Save();
        }
        public bool Delete(Product product)
        {
            _context.Remove(product);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0?true:false;
        }
    }
}

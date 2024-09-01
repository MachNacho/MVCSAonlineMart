using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAonlineMart.Data.Enum;
using SAonlineMart.Models;

namespace SAonlineMart.Interfaces
{
    public interface IProductRepository//interface for product
    {
        Task<IEnumerable<Product>> GetALL();
        Task<IEnumerable<Product>> GetALLbyDate();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByCategory(ProductCategory Category);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(Product product);
        bool Save();
    }
}
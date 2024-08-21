using Microsoft.EntityFrameworkCore;
using SAonlineMart.Models;

namespace SAonlineMart.Data
{
    public class ApplicationDBcontext: DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> Options):base(Options)
        {
        }
        public DbSet<Product> product { get; set; }
        public DbSet<Customer> customer  { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<cartItems> cartitems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAonlineMart.Data;
using SAonlineMart.Models;
using SAonlineMart.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SAonlineMart.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBcontext _context;
        public OrderRepository(ApplicationDBcontext context) { _context = context; }//DB

        public async Task<IEnumerable<Order>> GetAll(string userID)
        {
            return await _context.order.Where(x => x.customerID == userID).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int ORDERid)
        {
            return await _context.order.Include(x=>x.OrdersItems).FirstOrDefaultAsync(x => x.Id == ORDERid);
        }
    }
}
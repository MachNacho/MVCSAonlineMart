using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SAonlineMart.Data;
using SAonlineMart.Interfaces;
using SAonlineMart.Models;
using Azure;
using System.Collections.Generic;

namespace SAonlineMart.Repository
{

    public class CartRepository: ICartRepository
    {
        private readonly ApplicationDBcontext _context;
        public CartRepository(ApplicationDBcontext context) { _context = context; }//DB

        public bool Add(int PID,string userid)//add to cart
        {
            var CI = _context.cartitems.FirstOrDefault(x => x.customerID == userid && x.productID == PID);
            if (CI == null)
            {
                _context.cartitems.Add(new cartItems { customerID = userid, productID = PID, quantity = 1 });
            }
            return Save();
        }

        public async Task<IEnumerable<cartItems>> GetAll(string userID) //retirve all
        {
            return await _context.cartitems.Where(x => x.customerID == userID).
                Include(a => a.product).ToListAsync();
        }

        public bool MinusOne(int id)
        {
            cartItems p = _context.cartitems.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                return Save();
            }
            if (p.quantity == 1)
            {
              return Delete(p); 
            }
            p.quantity -= 1;
            return update(p);

        }
        public bool RemoveALL(IEnumerable<cartItems> i) 
        {
            _context.cartitems.RemoveRange(i);
            return Save();
        }
        public bool PlusOne(int id)
        {
            cartItems p = _context.cartitems.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                return Save();
            }
            p.quantity += 1;
            return update(p);
        }
        public bool RemoveOne(int id) 
        {
            cartItems cart = _context.cartitems.FirstOrDefault(c => c.Id == id);
            if (cart == null)
            {
                return Save();
            }
            return Delete(cart);
        }
        public bool Delete(cartItems cartItems)
        {
            _context.RemoveRange(cartItems);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool update(cartItems cartItems)
        {
            _context.cartitems.Update(cartItems);
            return Save();
        }
        public bool CompleteCheckout(Order o) 
        {
            _context.order.Add(o);
            return Save();
        }
    }
}

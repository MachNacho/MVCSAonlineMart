﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAonlineMart.Models;

namespace SAonlineMart.Data
{
	public class ApplicationDBcontext : IdentityDbContext<Customer>
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> Options):base(Options)//creates the db and sets the tables
        {
        }
        public DbSet<Product> product { get; set; }
        public DbSet<Customer> customer  { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<cartItems> cartitems { get; set; }
        public DbSet<OrderItems> orderItems { get; set; }
    }
}

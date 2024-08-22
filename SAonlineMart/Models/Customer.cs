using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAonlineMart.Models
{
    public class Customer: IdentityUser
    {
        public string FirstName { get; set; }
        public string LaststName { get; set; }
        public DateOnly birthDay { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<cartItems> cartItems { get; set; } = new List<cartItems>();
    }
}
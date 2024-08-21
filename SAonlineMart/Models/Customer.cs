using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SAonlineMart.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<cartItems> cartItems { get; set; } = new List<cartItems>();
    }
}
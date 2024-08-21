using SAonlineMart.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAonlineMart.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public ProductCategory productCategory { get; set; }
        public double productPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime ProdcutUpload { get; set; } = DateTime.Now;
        public string imageURL { get; set; } 
        //public List<User_Cart>? CartItems { get; set; }
    }
}
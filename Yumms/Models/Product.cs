using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yumms.Models
{
    public class Product
    {
        [Key] public int ProductID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int Product_TypeID { get; set; }
        public string Company { get; set; }

        public virtual Product_Type Product_Type { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
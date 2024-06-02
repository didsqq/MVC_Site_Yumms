using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Yumms.Models
{
    public class Order
    {
        [Key] public int OrderID { get; set; }
        public DateTime Date { get; set; }
        public decimal Total_Amount { get; set; }
        public string Status { get; set; }
        public int Product_Count { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
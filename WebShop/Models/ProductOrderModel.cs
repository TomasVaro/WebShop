using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ProductOrderModel
    {
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

        public int OrderId { get; set; }
        public OrderModel Order { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}

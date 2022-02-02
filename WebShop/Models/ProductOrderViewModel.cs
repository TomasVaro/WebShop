using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ProductOrderViewModel
    {
        public List<ProductModel> ListCartProduct { get; set; }
        public OrderModel NewOrder { get; set; }
        public ApplicationUser UserDetails { get; set; }

        public ProductOrderViewModel()
        {
            ListCartProduct = new List<ProductModel>();
        }
    }
}

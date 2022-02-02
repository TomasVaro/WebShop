using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class CartDetail
    {
        public string ProductId { get; set; }

        public CartDetail( string ? productId)
        {
            ProductId = productId;
        }
    }
}

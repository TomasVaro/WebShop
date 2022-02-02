using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class ProductViewModel : ProductModel
    {
        public List<ProductModel> ListProductView { get; set; }
        public List<ProductModel> ListCart { get; set; }
        public string Filter { get; set; }

        public ProductViewModel()
        {
            ListProductView = new List<ProductModel>();
            ListCart= new List<ProductModel>();
        }
    }
}

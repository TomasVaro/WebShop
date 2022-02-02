using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class OrderEditModel
    {
        public OrderModel Order { get; set; }
        public ProductModel Product { get; set; }
        public ProductOrderModel ProductOrder { get; set; }

        public List<ApplicationUser> ApplicationUser { get; set; }
        public List<OrderModel> OrderModel { get; set; }
        public List<ProductOrderModel> ProductOrderModel { get; set; }
        public List<ProductModel> ProductModel { get; set; }

        public OrderEditModel()
        {
            this.OrderModel = new List<OrderModel>();
            this.ProductOrderModel = new List<ProductOrderModel>();
            this.ProductModel = new List<ProductModel>();
        }
    }
 }
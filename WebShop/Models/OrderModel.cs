using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [Column("OrderDate")]
        public DateTime Date { get; set; }

        public ApplicationUser User { get; set; }
        public List<ProductOrderModel> Products { get; set; }
    }
}

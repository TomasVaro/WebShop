using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebShop.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Column("ProductName")]
        [MaxLength(50)]
        public string ProductName { get; set; }

        [Required]
        [Column("Price")]        
        public int Price { get; set; }

        [Required]
        [Column("Description")]
        public string Description { get; set; }

        [Required]
        [Column("ImageName")]
        [MaxLength(50)]
        public string ImageName { get; set; }

        public List<ProductOrderModel> Orders { get; set; }
    }
}

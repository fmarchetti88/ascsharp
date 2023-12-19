using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssoSw.Lesson7.AspNetCoreWebApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int QuantityWarehouse { get; set; }

        [SwaggerSchema("The orders' rows of the product")]
        internal ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

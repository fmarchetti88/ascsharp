using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AssoSw.Lesson7.AspNetCoreWebApi.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [SwaggerSchema("The quantity of the product in the order")]
        public int Quantity { get; set; }

        [Required]
        [SwaggerSchema("The order id")]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        [JsonIgnore]
        public Order Order { get; set; }

        [Required]
        [SwaggerSchema("The product id")]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public Product Product { get; set; }
    }
}

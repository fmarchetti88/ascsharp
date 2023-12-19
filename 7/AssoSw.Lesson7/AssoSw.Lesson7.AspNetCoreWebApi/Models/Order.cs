using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AssoSw.Lesson7.AspNetCoreWebApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [SwaggerSchema("The date and time when the order was placed")]
        public DateTime OrderPlaced { get; set; }

        [SwaggerSchema("The date and time when the order was fulfilled")]
        public DateTime? OrderFulfilled { get; set; }

        [Required]
        [SwaggerSchema("The customer id who placed the order")]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [JsonIgnore]
        public Customer Customer { get; set; }

        [SwaggerSchema("The order's rows")]
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

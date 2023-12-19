using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace AssoSw.Lesson7.AspNetCoreWebApi.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [SwaggerSchema(Description = "The full name of the customer")]
        public string BusinessName { get; set; }

        [SwaggerSchema(Description = "The VAT code of the customer")]
        [StringLength(11)]
        public string VatCode { get; set; }

        [SwaggerSchema(Description = "The fiscal code of the customer")]
        [StringLength(16)]
        public string FiscalCode { get; set; }

        [SwaggerSchema(Description = "The address of the customer")]
        [StringLength(255)]
        public string Address { get; set; }

        [SwaggerSchema(Description = "The telephone number of the customer")]
        [StringLength(30)]
        public string Telephone { get; set; }

        [SwaggerSchema(Description = "The email address of the customer")]
        [StringLength(100)]
        public string Email { get; set; }

        [SwaggerSchema(Description = "The orders of the customer")]
        public ICollection<Order> Orders { get; set; }
    }
}

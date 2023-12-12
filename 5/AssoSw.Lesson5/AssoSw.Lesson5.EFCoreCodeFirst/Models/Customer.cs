using System.ComponentModel.DataAnnotations;

namespace AssoSw.Lesson5.EFCoreCodeFirst.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? BusinessName { get; set; }

        [StringLength(12)]
        public string? VatCode { get; set; }

        [StringLength(20)]
        public string? FiscalCode { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        [StringLength(20)]
        public string? Telephone { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        /*
         * Null Forgiving Operator
         * Viene utilizzato per assegnare null a variabili non nullable, che è un modo 
         * per "promettere" che la variabile non sarà nulla quando verrà effettivamente utilizzata.
         */
        public ICollection<Order> Orders { get; set; } = null!;
    }
}

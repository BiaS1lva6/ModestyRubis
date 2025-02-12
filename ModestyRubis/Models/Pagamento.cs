using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    public class Pagamento
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Compra")]
        public long CompraId { get; set; }

        [Required]
        public string MetodoPagamento { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }

        public DateTime DataPagamento { get; set; } = DateTime.UtcNow;

        [Required]
        public string Status { get; set; }

        // Navigation property
        public virtual Compra Compra { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModestyRubis.Models
{
    public class Compra
    {
        [Key]
        public Guid CompraId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Cliente")]
        public Guid ClienteId { get; set; }

        public DateTime DataCompra { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ValorTotal { get; set; }

        // Navigation property
        public virtual Cliente Cliente { get; set; }
        public string Status { get; internal set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeltyRubis.Models
{
    public class Compra
    {
        [Key]
        public Guid CompraId { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public long ClienteId { get; set; }

        public DateTime DataCompra { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal ValorTotal { get; set; }
    }
}
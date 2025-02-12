using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    public class Compra
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public long ClienteId { get; set; }

        public DateTime DataCompra { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal ValorTotal { get; set; }
    }
}
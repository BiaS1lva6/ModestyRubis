using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    public class Devolucao
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Compra")]
        public long CompraId { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public long ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public string Motivo { get; set; }

        public DateTime DataDevolucao { get; set; } = DateTime.UtcNow;

        [Required]
        public string Status { get; set; }

        // Navigation properties
        public virtual Compra Compra { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
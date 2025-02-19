using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModestyRubis.Models
{
    public class Devolucao
    {
        [Key]
        public Guid DevolucaoId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Compra")]
        public Guid CompraId { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public Guid ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public string Motivo { get; set; }

        public DateTime DataDevolucao { get; set; } = DateTime.UtcNow;

        [Required]
        public string Status { get; set; }

        // Navigation properties
        public Compra? Compra { get; set; }
        public Produto? Produto { get; set; }
    }
}
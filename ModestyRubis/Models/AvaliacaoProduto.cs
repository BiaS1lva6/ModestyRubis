using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    public class AvaliacaoProduto
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public long ProdutoId { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public long ClienteId { get; set; }

        [Range(1, 5)]
        public int Avaliacao { get; set; }

        public string Comentario { get; set; }

        public DateTime Data { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Produto Produto { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
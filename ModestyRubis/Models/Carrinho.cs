using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    public class Carrinho
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public long ClienteId { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public long ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public DateTime DataAdicionado { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Cliente Cliente { get; set; }
        public virtual Produto Produto { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeltyRubis.Models
{
    public class Carrinho
    {
        [Key]
        public Guid CarrinhoId { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public Guid ClienteId { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public Guid ProdutoId { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public DateTime DataAdicionado { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual Cliente? Cliente { get; set; }
        public virtual Produto Produto { get; set; }
    }
}

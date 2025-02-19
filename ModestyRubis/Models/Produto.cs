using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModestyRubis.Models
{
    public class Produto
    {
        [Key]
        public Guid ProdutoId { get; set; } = Guid.NewGuid();

        [Required]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("Categoria")]
        public Guid CategoriaId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }

        public string Descricao { get; set; }

        // Navigation property
        public Categoria? Categoria { get; set; }
    }
}
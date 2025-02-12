
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModeltyRubis.Models
{
    public class Produto
    {
        [Key]
        public Guid ProdutoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [ForeignKey("Categoria")]
        public Guid CategoriaId { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }

        public string Descricao { get; set; }

        // Navigation property
        public virtual Categoria Categoria { get; set; }
    }
}

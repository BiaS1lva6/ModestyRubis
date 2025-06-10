using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class TamanhoProduto
    {
        [Key]
        public int Id { get; set; }

        public Guid ProdutoId { get; set; }

        [Required]
        [StringLength(10)]
        public string Tamanho { get; set; }

        [Required]
        public int QuantidadeEstoque { get; set; } = 0;

        public decimal? PrecoAdicional { get; set; } = 0;

        public bool Disponivel { get; set; } = true;

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataAtualizacao { get; set; }

        // Navigation Property
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        public ICollection<ItemCarrinho> ItensCarrinho { get; set; }
        public ICollection<ItemPedido> ItensPedido { get; set; }
    }
}


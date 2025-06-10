using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class ItemCarrinho
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid CarrinhoId { get; set; }  // Corrigido de int para Guid

        [Required]
        public Guid ProdutoId { get; set; }   // Corrigido de int para Guid

        [Required]
        [StringLength(10)]
        public string Tamanho { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoUnitario { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoTotal => Quantidade * PrecoUnitario;

        public DateTime DataAdicao { get; set; } = DateTime.Now;

        public DateTime? DataAtualizacao { get; set; }

        // Navigation Properties
        [ForeignKey("CarrinhoId")]
        public Carrinho Carrinho { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
    }

}

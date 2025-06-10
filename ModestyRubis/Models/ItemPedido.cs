using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid ProdutoId { get; set; } // <- Troque para Guid

        [Required]
        [StringLength(200)]
        public string NomeProduto { get; set; } // Snapshot do nome na época da compra

        [Required]
        [StringLength(10)]
        public string Tamanho { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoUnitario { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoTotal => Quantidade * PrecoUnitario;

        [StringLength(500)]
        public string UrlImagemProduto { get; set; } // Snapshot da imagem

        public DateTime DataAdicao { get; set; } = DateTime.Now;

        // Navigation Properties
        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }


    }
}

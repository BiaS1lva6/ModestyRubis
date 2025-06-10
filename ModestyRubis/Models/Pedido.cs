using static ModestyRubis.Models.Endereco;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroPedido { get; set; }

        [Required]
        public Guid UsuarioId { get; set; }

        public int? EnderecoEntregaId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorFrete { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal Desconto { get; set; } = 0;

        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorTotal { get; set; }

        [Required]
        public int StatusPedidoId { get; set; } = 1; // Pendente por padrão

        public int? FormaPagamentoId { get; set; }

        public int StatusPagamentoId { get; set; } = 1; // Pendente por padrão

        [StringLength(100)]
        public string CupomDesconto { get; set; }

        [StringLength(500)]
        public string Observacoes { get; set; }

        [StringLength(100)]
        public string CodigoRastreamento { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;

        public DateTime? DataConfirmacao { get; set; }

        public DateTime? DataEnvio { get; set; }

        public DateTime? DataEntrega { get; set; }

        public DateTime? DataCancelamento { get; set; }

        [StringLength(500)]
        public string MotivoCancelamento { get; set; }

        // Navigation Properties
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [ForeignKey("EnderecoEntregaId")]
        public Endereco EnderecoEntrega { get; set; }

        [ForeignKey("StatusPedidoId")]
        public StatusPedido StatusPedido { get; set; }

        public ICollection<ItemPedido> Itens { get; set; }
        public ICollection<Pagamento> Pagamentos { get; set; }

        public string ObservacaoAdmin { get; set; }
    }
}

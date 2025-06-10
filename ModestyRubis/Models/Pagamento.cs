using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModestyRubis.Models
{
    public class Pagamento
    {
        [Key]
        public int PagamentoId { get; set; }

        [ForeignKey("Pedido")]
        public int PedidoId { get; set; }

        [Required, StringLength(50)]
        public string FormaPagamento { get; set; }

        [Required, StringLength(50)]
        public string StatusPagamento { get; set; }

        [Required]
        public decimal Valor { get; set; }

        public string? TransactionId { get; set; }
        [Required]
        public DateTime DataPagamento { get; set; }

        public string? DadosCartao { get; set; }
        public int? Parcelas { get; set; }

        public Pedido Pedido { get; set; }
    }

}
namespace ModestyRubis.Models
{
    public class HistoricoStatusPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int StatusAnterior { get; set; }
        public int StatusNovo { get; set; }
        public string Observacao { get; set; }
        public Guid? UsuarioId { get; set; }
        public DateTime DataAlteracao { get; set; }

        public Pedido Pedido { get; set; }
        public Usuario Usuario { get; set; }
    }
}

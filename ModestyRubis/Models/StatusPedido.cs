using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class StatusPedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Descricao { get; set; }

        [StringLength(20)]
        public string Cor { get; set; } // Para exibição na UI (ex: "success", "warning", "danger")

        public int Ordem { get; set; } // Para ordenação

        public bool Ativo { get; set; } = true;

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // Navigation Properties
        public ICollection<Pedido> Pedidos { get; set; }
    }
}

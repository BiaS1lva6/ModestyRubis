using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(9)]
        [RegularExpression(@"^\d{5}-?\d{3}$", ErrorMessage = "CEP inválido")]
        public string CEP { get; set; }

        [Required]
        [StringLength(200)]
        public string Logradouro { get; set; }

        [Required]
        [StringLength(20)]
        public string Numero { get; set; }

        [StringLength(100)]
        public string Complemento { get; set; }

        [Required]
        [StringLength(100)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string Estado { get; set; }

        [StringLength(100)]
        public string PontoReferencia { get; set; }

        public bool EnderecoPrincipal { get; set; } = false;

        public bool Ativo { get; set; } = true;

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataAtualizacao { get; set; }

        // Navigation Property
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public ICollection<Pedido> PedidosEntrega { get; set; }
    }
}

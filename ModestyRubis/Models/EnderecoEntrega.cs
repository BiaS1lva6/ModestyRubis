using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourNamespace.Models
{
    public class EnderecoEntrega
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public long ClienteId { get; set; }

        [Required]
        public string Endereco { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Cep { get; set; }

        [Required]
        public string Pais { get; set; }

        // Navigation property
        public virtual Cliente Cliente { get; set; }
    }
}
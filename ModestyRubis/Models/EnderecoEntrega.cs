using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModestyRubis.Models
{
    public class EnderecoEntrega
    {
        [Key]
        public Guid EnderecoEntregaId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Cliente")]
        public Guid ClienteId { get; set; }

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
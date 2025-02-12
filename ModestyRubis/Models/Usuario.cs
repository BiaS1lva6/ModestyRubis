using System;
using System.ComponentModel.DataAnnotations;

namespace ModeltyRubis.Models
{
    public class Usuario
    {
        [Key]
        public Guid UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeUsuario { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public DateTime? UltimoLogin { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class Usuario
    {
        [Key]
        public Guid UsuarioId { get; set; } = Guid.NewGuid();

        [Required]
        public string NomeUsuario { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public DateTime? UltimoLogin { get; set; }
        public bool Ativo { get; set; } = true;
        public string TipoUsuario { get; set; } // "Cliente" ou "Admin"
    }
}
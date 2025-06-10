using System;
using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
    }
}
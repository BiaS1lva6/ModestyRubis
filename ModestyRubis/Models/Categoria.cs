using System;
using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
    }
}
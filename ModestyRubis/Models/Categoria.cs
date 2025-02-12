using System.ComponentModel.DataAnnotations;

namespace ModeltyRubis.Models
{
    public class Categoria
    {
        [Key]
        public long CategoriaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
    }
}
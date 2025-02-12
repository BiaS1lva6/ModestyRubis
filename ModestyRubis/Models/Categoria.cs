using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Categoria
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
    }
}
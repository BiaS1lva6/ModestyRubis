using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ModestyRubis.Models
{
    public class ImagemProduto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid ProdutoId { get; set; }

        [Required]
        [StringLength(500)]
        public string UrlImagem { get; set; }

        [StringLength(200)]
        public string AltText { get; set; }

        public int Ordem { get; set; } = 0;

        public bool Principal { get; set; } = false;

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public bool Ativo { get; set; } = true;

        // Navigation Property
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
    }
}



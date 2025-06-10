using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class Frete
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(9)]
        public string CEPOrigem { get; set; }

        [Required]
        [StringLength(9)]
        public string CEPDestino { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,3)")]
        public decimal Peso { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Altura { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Largura { get; set; }

        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Comprimento { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorDeclarado { get; set; }

        [Required]
        public int TipoFreteId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [Required]
        public int PrazoEntrega { get; set; }

        public DateTime DataConsulta { get; set; } = DateTime.Now;

        public bool Ativo { get; set; } = true;


    }

}

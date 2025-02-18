using System;
using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class CupomDesconto
    {
        [Key]
        public Guid CupomDescontoId { get; set; } = Guid.NewGuid();

        [Required]
        public string Codigo { get; set; }

        public string Descricao { get; set; }

        [Range(0, 100)]
        public decimal? DescontoPercentual { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public int? UsoMaximo { get; set; }
    }
}
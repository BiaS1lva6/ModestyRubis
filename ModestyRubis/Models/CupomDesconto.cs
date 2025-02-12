using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class CupomDesconto
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }

        public string Descricao { get; set; }

        [Range(0, 100)]
        public decimal DescontoPercentual { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public int? UsoMaximo { get; set; }
    }
}
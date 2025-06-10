using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{

    public class InformacaoCEP
    {
        [Key]
        [StringLength(9)]
        public string CEP { get; set; }

        [Required]
        [StringLength(200)]
        public string Logradouro { get; set; }

        [StringLength(100)]
        public string Complemento { get; set; }

        [Required]
        [StringLength(100)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2)]
        public string Estado { get; set; }

        [Required]
        [StringLength(100)]
        public string EstadoCompleto { get; set; }

        [StringLength(20)]
        public string IBGE { get; set; }

        [StringLength(10)]
        public string GIA { get; set; }

        [StringLength(10)]
        public string DDD { get; set; }

        [StringLength(10)]
        public string SIAFI { get; set; }

        public DateTime DataConsulta { get; set; } = DateTime.Now;

        public DateTime? DataAtualizacao { get; set; }

        public bool Ativo { get; set; } = true;
    }
}

﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModestyRubis.Models
{
    public class Pagamento
    {
        [Key]
        public Guid PagamentoId { get; set; } = Guid.NewGuid();

        [Required]
        [ForeignKey("Compra")]
        public Guid CompraId { get; set; }

        [Required]
        public string MetodoPagamento { get; set; }

        [Required]
        //[Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }

        public DateTime DataPagamento { get; set; } = DateTime.UtcNow;

        [Required]
        public string Status { get; set; }

        // Navigation property
        public Compra? Compra { get; set; }
    }
}
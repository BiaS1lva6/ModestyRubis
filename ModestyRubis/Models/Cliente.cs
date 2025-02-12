﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ModeltyRubis.Models
{
    public class Cliente
    {
        [Key]
        public Guid ClienteIdId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public DateTime? DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}

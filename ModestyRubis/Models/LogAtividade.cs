namespace ModestyRubis.Models
{
    public class LogAtividade
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string Acao { get; set; }
        public string Entidade { get; set; }
        public int? EntidadeId { get; set; }
        public string DetalhesAntes { get; set; }
        public string DetalhesDepois { get; set; }
        public string EnderecoIP { get; set; }
        public DateTime DataHora { get; set; }

        public Usuario Usuario { get; set; }
    }
}

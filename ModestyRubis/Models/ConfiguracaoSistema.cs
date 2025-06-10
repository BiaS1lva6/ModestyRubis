namespace ModestyRubis.Models
{
    public class ConfiguracaoSistema
    {
        public int Id { get; set; }
        public string Chave { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }
        public string Tipo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ModestyRubis.Models
{
    public class CupomCarrinho
    {
        [Key]
        public Guid CupomCarrinhoId { get; set; }
        public Guid CarrinhoId { get; set; }
        public Carrinho? Carrinho { get; set; }
        public Guid CupomId { get; set; }
        public CupomDesconto? CupomDesconto { get; set; }
        public DateTime? DataAplicacao { get; set; }
    }
}

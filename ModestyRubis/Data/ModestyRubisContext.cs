using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace ModestyRubis.Data
{
    public class ModestyRubisContext : DbContext
    {
        public ModestyRubisContext (DbContextOptions<ModestyRubisContext> options)
            : base(options)
        {
        }

        public DbSet<YourNamespace.Models.AvaliacaoProduto> AvaliacaoProduto { get; set; } = default!;
        public DbSet<YourNamespace.Models.Carrinho> Carrinho { get; set; } = default!;
        public DbSet<YourNamespace.Models.Categoria> Categoria { get; set; } = default!;
        public DbSet<YourNamespace.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<YourNamespace.Models.Compra> Compra { get; set; } = default!;
        public DbSet<YourNamespace.Models.CupomDesconto> CupomDesconto { get; set; } = default!;
        public DbSet<YourNamespace.Models.Devolucao> Devolucao { get; set; } = default!;
        public DbSet<YourNamespace.Models.EnderecoEntrega> EnderecoEntrega { get; set; } = default!;
        public DbSet<YourNamespace.Models.Pagamento> Pagamento { get; set; } = default!;
        public DbSet<YourNamespace.Models.Produto> Produto { get; set; } = default!;
        public DbSet<YourNamespace.Models.Usuario> Usuario { get; set; } = default!;
    }
}

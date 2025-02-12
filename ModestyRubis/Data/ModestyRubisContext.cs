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
    }
}

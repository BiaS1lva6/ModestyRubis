using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModestyRubis.Models;

namespace ModestyRubis.Data
{
    public class ModestyRubisContext : DbContext
    {
        public ModestyRubisContext(DbContextOptions<ModestyRubisContext> options)
            : base(options)
        {
        }
        public DbSet<AvaliacaoProduto> AvaliacaoProduto { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<CupomDesconto> CupomDesconto { get; set; }
        public DbSet<Devolucao> Devolucao { get; set; }
        public DbSet<EnderecoEntrega> EnderecoEntrega { get; set; }
        public DbSet<HistoricoCarrinho> HistoricoCarrinho { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AvaliacaoProduto>().ToTable("AvaliacaoProdutos");
            modelBuilder.Entity<Carrinho>().ToTable("Carrinhos");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Compra>().ToTable("Compras");
            modelBuilder.Entity<CupomDesconto>().ToTable("CupomDescontos");
            modelBuilder.Entity<Devolucao>().ToTable("Devolucaos");
            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecoEntregas");
            modelBuilder.Entity<HistoricoCarrinho>().ToTable("HistoricoCarrinhos");
            modelBuilder.Entity<Pagamento>().ToTable("Pagamentos");
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

        }
    }
}

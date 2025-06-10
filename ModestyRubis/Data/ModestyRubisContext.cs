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
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<CupomDesconto> CupomDesconto { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<EnderecoEntrega> EnderecoEntrega { get; set; }
        public DbSet<Frete> Frete { get; set; }
        public DbSet<HistoricoCarrinho> HistoricoCarrinho { get; set; }
        public DbSet<ImagemProduto> ImagemProduto { get; set; }
        public DbSet<InformacaoCEP> InformacaoCEP { get; set; }
        public DbSet<ItemCarrinho> ItemCarrinho { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<TamanhoProduto> TamanhoProduto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<StatusPedido> StatusPedido { get; set; }
        public DbSet<HistoricoStatusPedido> HistoricoStatusPedido { get; set; }
        public DbSet<LogAtividade> LogAtividades { get; set; }
        public DbSet<ConfiguracaoSistema> ConfiguracaoSistemas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Carrinho>().ToTable("Carrinhos");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            modelBuilder.Entity<Compra>().ToTable("Compras");
            modelBuilder.Entity<CupomDesconto>().ToTable("CupomDescontos");
            modelBuilder.Entity<EnderecoEntrega>().ToTable("EnderecoEntregas");
            modelBuilder.Entity<HistoricoCarrinho>().ToTable("HistoricoCarrinhos");
            modelBuilder.Entity<Pagamento>().ToTable("Pagamentos");
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Frete>().ToTable("Fretes");
            modelBuilder.Entity<Endereco>().ToTable("Enderecos");
            modelBuilder.Entity<ImagemProduto>().ToTable("ImagemProdutos");
            modelBuilder.Entity<InformacaoCEP>().ToTable("IndormacaoCEPs");
            modelBuilder.Entity<ItemCarrinho>().ToTable("ItemCarrinhos");
            modelBuilder.Entity<ItemPedido>().ToTable("ItemPedidos");
            modelBuilder.Entity<TamanhoProduto>().ToTable("TamanhoProdutos");
            modelBuilder.Entity<Pedido>().ToTable("Pedidos");
            modelBuilder.Entity<StatusPedido>().ToTable("StatusPedidos");
            modelBuilder.Entity<HistoricoStatusPedido>().ToTable("HistoricoStatusPedidos");
            modelBuilder.Entity<LogAtividade>().ToTable("LogAtividades");
            modelBuilder.Entity<ConfiguracaoSistema>().ToTable("ConfiguracaoSistemas");

        }
        public DbSet<ModestyRubis.Models.CupomCarrinho> CupomCarrinho { get; set; } = default!;
    }
}

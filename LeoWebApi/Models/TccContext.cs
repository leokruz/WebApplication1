using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoDatabase.Models
{
    public class TccContext : DbContext
    {
        public TccContext() : base("TutoriaDB") {

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<StatusPedido> StatusPedido { get; set; }
        public DbSet<AvaliacaoCliente> AvaliacoesCliente { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}

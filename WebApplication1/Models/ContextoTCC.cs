using LeoFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LeoFrontEnd.Models
{
    public class ContextoTCC : DbContext
    {
        public ContextoTCC() : base("DropshippingDB") { }

        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<LoginModel> Logins { get; set; }
        public DbSet<FornecedorModel> Fornecedores { get; set; }
        public DbSet<PerfilModel> Perfis { get; set; }
        public DbSet<PedidoModel> Pedidos { get; set; }
        public DbSet<PedidoItemModel> CreateDbs { get; set; }
        public DbSet<StatusPedidoModel> StatusPedido { get; set; }
        public DbSet<AvaliacaoModel> Avaliacoes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public System.Data.Entity.DbSet<LeoFrontEnd.Models.ProdutoModel> ProdutoModels { get; set; }

        public System.Data.Entity.DbSet<LeoFrontEnd.Models.CarrinhoModel> CarrinhoModels { get; set; }
    }
}
namespace CreateDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeoMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvaliacaoClientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nota = c.Int(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 150),
                        DataInclusao = c.DateTime(nullable: false),
                        Cliente_Id = c.Int(),
                        PedidoItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Cliente_Id)
                .ForeignKey("dbo.PedidoItem", t => t.PedidoItem_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.PedidoItem_Id);
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        DataNascimento = c.DateTime(nullable: false),
                        Cpf = c.Long(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 1),
                        Telefone = c.String(nullable: false, maxLength: 20),
                        Endereco = c.String(nullable: false, maxLength: 80),
                        Cep = c.String(nullable: false, maxLength: 8),
                        UsuarioAtualizacao = c.String(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Senha = c.String(nullable: false, maxLength: 20),
                        IdPerfil = c.Int(nullable: false),
                        UsuarioAtualizacao = c.String(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCliente = c.Int(nullable: false),
                        Valor = c.Double(nullable: false),
                        IdFormaPagamento = c.Int(nullable: false),
                        UsuarioAtualizacao = c.String(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                        Fornecedor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.IdCliente, cascadeDelete: true)
                .ForeignKey("dbo.Fornecedor", t => t.Fornecedor_Id)
                .Index(t => t.IdCliente)
                .Index(t => t.Fornecedor_Id);
            
            CreateTable(
                "dbo.PedidoItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        IdFornecedor = c.Int(nullable: false),
                        IdProduto = c.Int(nullable: false),
                        NomeProduto = c.String(nullable: false, maxLength: 100),
                        ValorFornecedor = c.Double(nullable: false),
                        ValorVenda = c.Double(nullable: false),
                        DataPedido = c.DateTime(nullable: false),
                        UsuarioAtualizacao = c.String(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedor", t => t.IdFornecedor, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.IdPedido, cascadeDelete: true)
                .Index(t => t.IdPedido)
                .Index(t => t.IdFornecedor);
            
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 80),
                        CpfCnpj = c.String(nullable: false, maxLength: 14),
                        URLServico = c.String(nullable: false, maxLength: 50),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        UsuarioAtualizacao = c.String(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusPedido",
                c => new
                    {
                        IdStatusPedido = c.Int(nullable: false, identity: true),
                        IdPedido = c.Int(nullable: false),
                        DescStatus = c.String(nullable: false, maxLength: 20),
                        DataInclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdStatusPedido)
                .ForeignKey("dbo.Pedido", t => t.IdPedido, cascadeDelete: true)
                .Index(t => t.IdPedido);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StatusPedido", "IdPedido", "dbo.Pedido");
            DropForeignKey("dbo.AvaliacaoClientes", "PedidoItem_Id", "dbo.PedidoItem");
            DropForeignKey("dbo.PedidoItem", "IdPedido", "dbo.Pedido");
            DropForeignKey("dbo.PedidoItem", "IdFornecedor", "dbo.Fornecedor");
            DropForeignKey("dbo.Pedido", "Fornecedor_Id", "dbo.Fornecedor");
            DropForeignKey("dbo.AvaliacaoClientes", "Cliente_Id", "dbo.Cliente");
            DropForeignKey("dbo.Pedido", "IdCliente", "dbo.Cliente");
            DropForeignKey("dbo.Login", "Id", "dbo.Cliente");
            DropIndex("dbo.StatusPedido", new[] { "IdPedido" });
            DropIndex("dbo.PedidoItem", new[] { "IdFornecedor" });
            DropIndex("dbo.PedidoItem", new[] { "IdPedido" });
            DropIndex("dbo.Pedido", new[] { "Fornecedor_Id" });
            DropIndex("dbo.Pedido", new[] { "IdCliente" });
            DropIndex("dbo.Login", new[] { "Id" });
            DropIndex("dbo.AvaliacaoClientes", new[] { "PedidoItem_Id" });
            DropIndex("dbo.AvaliacaoClientes", new[] { "Cliente_Id" });
            DropTable("dbo.StatusPedido");
            DropTable("dbo.Fornecedor");
            DropTable("dbo.PedidoItem");
            DropTable("dbo.Pedido");
            DropTable("dbo.Login");
            DropTable("dbo.Cliente");
            DropTable("dbo.AvaliacaoClientes");
        }
    }
}

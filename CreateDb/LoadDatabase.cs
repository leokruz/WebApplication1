using CreateDb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDb
{
    public class LoadDatabase
    {
        public static void CreateTables(bool zeraBd, string senhaEcryptValue)
        {
            try
            {
                using (var _contexto = new TccContext())
                {
                    if (zeraBd)
                        _contexto.Database.Delete();

                    #region Criação do Cliente/Login/endereços
                    //var perfil = new Perfil
                    //{
                    //    Id = 1,
                    //    Descricao = "Administrador"
                    //};

                    //_contexto.Perfis.Add(perfil);

                    //var cliente = new Cliente
                    //{
                    //    Nome = "Administrador do Sistema",
                    //    DataNascimento = new DateTime(1950, 01, 01),
                    //    Cpf = 12345678900,
                    //    Sexo = "M",
                    //    Telefone = "(71) 99963-6363"
                    //};

                    //_contexto.Clientes.Add(cliente);

                    //var login = new Login
                    //{
                    //    Cliente = cliente,
                    //    Email = "adm@leo.com",
                    //    Perfil = perfil,
                    //    Senha = senhaEcryptValue,
                    //};

                    //_contexto.Logins.Add(login);

                    //perfil = new Perfil
                    //{
                    //    Id = 2,
                    //    Descricao = "Cliente"
                    //};

                    //_contexto.Perfis.Add(perfil);

                    //cliente = new Cliente
                    //{
                    //    Nome = "Antonio Pinheiro da Silva",
                    //    DataNascimento = new DateTime(1974, 06, 01),
                    //    Cpf = 24735213520,
                    //    Sexo = "M",
                    //    Telefone = "(71) 99963-6363"
                    //};

                    //_contexto.Clientes.Add(cliente);

                    //login = new Login
                    //{
                    //    Cliente = cliente,
                    //    Email = "cliente@leo.com",
                    //    Perfil = perfil,
                    //    Senha = senhaEcryptValue,
                    //};

                    //_contexto.Logins.Add(login);



                    //var endereco1 = new Endereco
                    //{
                    //    Cliente = cliente,
                    //    Rua = "Rua Teste",
                    //    Numero = 111,
                    //    Bairro = "Centro",
                    //    Cep = "12345-678",
                    //    Cidade = "São Paulo",
                    //    UF = "SP",
                    //    Pais = "Brasil"
                    //};

                    //_contexto.Enderecos.Add(endereco1);

                    //#endregion

                    //#region Criação dos Fornecedores e Dominios

                    //var fornecedor1 = new Fornecedor
                    //{
                    //    Nome = "Americanas",
                    //    CpfCnpj = "51762753000175",
                    //    URLApi = "http://api.hom.submarino/Produtos",
                    //    Login = "Luiz-TCC-Submarino",
                    //    Senha = Program.EncryptValue("Sub123!@#")
                    //};

                    //_contexto.Fornecedores.Add(fornecedor1);


                    ////var dominio_status1 = new Dominio { Nome = "STATUS_PEDIDO", Descricao = "PEDIDO EFETUADO", Valor = "1", ClienteManutencao = "LUIZEDUA" };
                    ////var dominio_status2 = new Dominio { Nome = "STATUS_PEDIDO", Descricao = "PAGAMENTO AUTORIZADO", Valor = "2", ClienteManutencao = "LUIZEDUA" };
                    ////var dominio_status3 = new Dominio { Nome = "STATUS_PEDIDO", Descricao = "NOTA FISCAL EMITIDA", Valor = "3", ClienteManutencao = "LUIZEDUA" };
                    ////var dominio_status4 = new Dominio { Nome = "STATUS_PEDIDO", Descricao = "EM TRANSPORTE", Valor = "4", ClienteManutencao = "LUIZEDUA" };
                    ////var dominio_status5 = new Dominio { Nome = "STATUS_PEDIDO", Descricao = "PRODUTO ENTREGUE", Valor = "5", ClienteManutencao = "LUIZEDUA" };

                    ////_contexto.Dominios.Add(dominio_status1);
                    ////_contexto.Dominios.Add(dominio_status2);
                    ////_contexto.Dominios.Add(dominio_status3);
                    ////_contexto.Dominios.Add(dominio_status4);
                    ////_contexto.Dominios.Add(dominio_status5);

                    //#endregion

                    //#region Criação do Pedido

                    ////var pedido = new Pedido
                    ////{
                    ////    Cliente = cliente,
                    ////    IdEnderecoRef = 1,
                    ////    ClienteManutencao = "LUIZEDUA",
                    ////    IdFormaPagamento = 1
                    ////};

                    ////_contexto.Pedidos.Add(pedido);

                    ////var pedidoProduto1 = new CreateDb
                    ////{
                    ////    Pedido = pedido,
                    ////    IdProdutoFornecedor = 3659,
                    ////    NomeProduto = "SMARTPHONE SAMSUNG GALAXY J7 3GB/32GB",
                    ////    Imagem = string.Empty,
                    ////    ValorFornecedor = 799.90,
                    ////    ValorFinal = ObterValorFinal(0.2, 799.90),
                    ////    Fornecedor = fornecedor1,
                    ////    ClienteManutencao = "LUIZEDUA"
                    ////};

                    ////var pedidoProduto2 = new CreateDb
                    ////{
                    ////    Pedido = pedido,
                    ////    IdProdutoFornecedor = 9966,
                    ////    NomeProduto = "CARTÃO DE MEMÓRIA KINGSTON 32GB",
                    ////    Imagem = string.Empty,
                    ////    ValorFornecedor = 49.90,
                    ////    ValorFinal = ObterValorFinal(0.2, 49.90),
                    ////    Fornecedor = fornecedor2,
                    ////    ClienteManutencao = "LUIZEDUA"
                    ////};

                    ////_contexto.CreateDbs.Add(pedidoProduto1);
                    ////_contexto.CreateDbs.Add(pedidoProduto2);

                    ////var statusPedido1 = new StatusPedido
                    ////{
                    ////    Pedido = pedido,
                    ////    Status = "1",
                    ////    ClienteManutencao = "LUIZEDUA"
                    ////};

                    ////var statusPedido2 = new StatusPedido
                    ////{
                    ////    Pedido = pedido,
                    ////    Status = "2",
                    ////    ClienteManutencao = "EXTRA"
                    ////};

                    ////_contexto.StatusPedido.Add(statusPedido1);
                    ////_contexto.StatusPedido.Add(statusPedido2);

                    ////var frete = new Frete
                    ////{
                    ////    IdPedidoRef = pedido.IdPedido,
                    ////    CodigoRastreio = "BR6645155XPTO",
                    ////    DtPrevisaoEntrega = DateTime.Now.AddDays(10),
                    ////    Valor = 15,
                    ////    ClienteManutencao = "LUIZEDUA"
                    ////};

                    ////_contexto.Frete.Add(frete);

                    //#endregion

                    //#region Avaliação

                    ////var avaliacao = new Avaliacao
                    ////{
                    ////    Cliente = cliente,
                    ////    CreateDb = pedidoProduto1,
                    ////    Nota = 10,
                    ////    Descricao = "Ótimo celular",
                    ////    ClienteManutencao = "LUIZEDUA"
                    ////};

                    ////_contexto.Avaliacao.Add(avaliacao);

                    #endregion

                    _contexto.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                }

                throw;
            }
        }

        public static double ObterValorFinal(double percentual, double valor)
        {
            return (valor * percentual) + valor;
        }
    }
}

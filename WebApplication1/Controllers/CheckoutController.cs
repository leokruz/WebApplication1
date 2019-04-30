using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Util;

namespace WebApplication1.Controllers
{
    public class CheckoutController : Controller
    {
        public LoginModel Login
        {
            get { return (LoginModel)Session["Login"]; }
        }

        public CarrinhoModel Carrinho
        {
            get { return (CarrinhoModel)Session["SessionCarrinho"]; }
        }

        // GET: Checkout
        public ActionResult Index()
        {
            if (Login != null)
            {
                var model = new CheckoutModel();
                
                model.IdCliente = Login.Id;
                model.Carrinho = Carrinho;

                return View(model);
            }

            return RedirectToAction("AcessoNegado", "Login");
        }

        [HttpPost]
        public ActionResult Index(CheckoutModel model)
        {
            if (ModelState.IsValid)
            {
                var apiServico = new ApiServico();

                // gravar Pedido
                var pedido = new PedidoModel
                {
                    IdCliente = model.IdCliente,
                    IdFormaPagamento = model.IdFormaPagamento,
                    UsuarioAtualizacao = "LEONARDO",
                    DataAtualizacao = DateTime.Now,
                    Valor = 3000
                };

                var idPedido = apiServico.InserirPedido(pedido);

                // gravar PedidoProduto (para cada produto)
                foreach (var item in Carrinho.Itens)
                {
                    for (int i = 0; i < item.Quantidade; i++)
                    {
                        var pedidoItem = new PedidoItemModel
                        {
                            IdPedido = idPedido,
                            IdProdutoFornecedor = item.IdProduto,
                            IdFornecedor = item.IdFornecedor,
                            NomeProduto = item.Nome,
                            Imagem = string.Empty,
                            ValorFornecedor = item.ValorFornecedor,
                            ValorVenda = item.ValorVenda,
                            UsuarioAtualizacao = "LEONARDO"
                        };

                        var idPedidoProduto = apiServico.InserirPedidoItem(pedidoItem);
                    }
                }

                // gravar Status do Pedido
                var statusPedido = new StatusPedidoModel
                {
                    IdPedido = idPedido,
                    IdStatusPedido = 1,
                    DescStatus = "Pedido Recebido",
                    DataInclusao = DateTime.Now  
                };

                var idStatusPedido = apiServico.InserirStatusPedido(statusPedido);
                               

                // Zerar Carrinho
                Session["SessionCarrinho"] = null;

                var sucesso = new PedidoFinalizadoModel();


                return View("Sucesso", sucesso);
            }
            else
            {
                model.IdCliente = Login.Id;
                model.Carrinho = Carrinho;
                return View(model);
            }
        }

    }
}
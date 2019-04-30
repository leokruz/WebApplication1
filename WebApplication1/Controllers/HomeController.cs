using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Util;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var apiServico = new ApiServico();

             ViewData["Produtos"] = apiServico.ObterProdutos();
             ViewBag.NomePesquisa = "";

            ViewBag.Message = "Bem vindo a nossa loja!";
            return View();


            //string ApiBaseUrl = "http://localhost:62735/"; // endereço da sua api
            //string MetodoPath = "api/produto"; //caminho do método a ser chamado

            //var model = new ProdutoModel();
            //try
            //{
            //    var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + MetodoPath);
            //    httpWebRequest.ContentType = "application/json";
            //    httpWebRequest.Method = "GET";

            //    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //    {
            //        var retorno = JsonConvert.DeserializeObject<List<ProdutoModel>>(streamReader.ReadToEnd());

            //        if (retorno != null)
            //            ViewData["Produtos"] = retorno;

            //        //model.ListaProdutos = retorno;
            //    }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}


            //return View(model);
        }

        public ActionResult Details(int id)
        {
            var servico = new Util.ApiServico();
            var model = servico.GetProdutoPorId(id);

            if (model == null)
                return View();

            return View(model);


            //Fornecedor.WebService1 ws = new Fornecedor.WebService1();
            //ProdutoModel p = new ProdutoModel();
            //List<ProdutoModel> listaProduto = new List<ProdutoModel>();
            //var model = ws.ObterProdutoPorId(id);

            //p.Id = model.Id;
            //p.Nome = model.Nome;
            //p.Descricao = model.Descricao;
            //p.IdFornecedor = model.IdFornecedor;
            //p.ImgProduto = model.ImgProduto;
            //p.ValorFornecedor = model.ValorFornecedor;

            //if (p == null)
            //    return View();

            //return View(p);
        }

        [HttpPost]
        public ActionResult Details(ProdutoModel produto)
        {
            if (produto.Quantidade > 0)
            {

                // Cria um carrinho vazio na sessão se ele não exitir
                if (Session["SessionCarrinho"] == null)
                    Session["SessionCarrinho"] = new CarrinhoModel();

                // Pega o carrinho atual da Sessão
                var carrinho = (Models.CarrinhoModel)Session["SessionCarrinho"];

                carrinho.AddItem(produto);

                return RedirectToAction("Index", "Carrinho");
            }
            else
            {
                ViewBag.Mensagem = "Informe a quantidade!";
            }

            return View(produto);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
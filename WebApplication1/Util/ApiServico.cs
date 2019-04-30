using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Util
{
    public class ApiServico
    {

        public class RetornoServico
        {
            public RetornoServico()
            {
                Status = HttpStatusCode.OK;
            }

            public HttpStatusCode Status { get; set; }
            public string Objeto { get; set; }
            public string Mensagem { get; set; }
        }

        public RetornoServico ChamadaGet(string metodo)
        {
            var resp = new RetornoServico();
            string ApiBaseUrl = "http://localhost:62735/";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + metodo);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    resp.Objeto = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;

                if (res.StatusCode == HttpStatusCode.NotFound)
                {
                    resp.Status = HttpStatusCode.NotFound;
                    resp.Mensagem = "Registro não encontrado.";
                }
            }
            return resp;
        }

        public RetornoServico ChamadaPost(string metodo, string objetoJson)
        {
            var resp = new RetornoServico();

            try
            {
                string ApiBaseUrl = "http://localhost:62735/";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + metodo);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(objetoJson);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    resp.Objeto = streamReader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse res = (HttpWebResponse)ex.Response;

                if (res.StatusCode == HttpStatusCode.NotFound)
                {
                    resp.Status = HttpStatusCode.NotFound;
                    resp.Mensagem = "Registro não encontrado.";
                }
            }

            return resp;
        }

        public string ObjetoToJson(object obj)
        {
            return new JavaScriptSerializer().Serialize(obj).Replace("[", "").Replace("]", "");
        }

        #region produtos

        public List<ProdutoModel> ObterProdutos()
        {
            var metodo = "api/produto/";
            var produtos = new List<ProdutoModel>();
            var retornoApi = ChamadaGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
                produtos = JsonConvert.DeserializeObject<List<ProdutoModel>>(retornoApi.Objeto);

            return produtos;
        }

        public ProdutoModel GetProdutoPorId(int id)
        {
            var metodo = "api/produto/" + id;
            ProdutoModel produto = null;
            var retornoApi = ChamadaGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
                produto = JsonConvert.DeserializeObject<ProdutoModel>(retornoApi.Objeto);

            return produto;
        }

        #endregion

        #region Pedido

        public int InserirPedido(PedidoModel pedido)
        {
            var metodo = "api/pedido/";
            var objeto = ObjetoToJson(pedido);
            var retornoApi = ChamadaPost(metodo, objeto);

            if (retornoApi.Status == HttpStatusCode.OK)
                pedido = JsonConvert.DeserializeObject<PedidoModel>(retornoApi.Objeto);

            return pedido.Id;
        }

        public int InserirPedidoItem(PedidoItemModel pedidoItem)
        {
            var metodo = "api/pedidoItem/";
            var objeto = ObjetoToJson(pedidoItem);
            var retornoApi = ChamadaPost(metodo, objeto);

            if (retornoApi.Status == HttpStatusCode.OK)
                pedidoItem = JsonConvert.DeserializeObject<PedidoItemModel>(retornoApi.Objeto);

            return pedidoItem.Id;
        }

        public int InserirStatusPedido(StatusPedidoModel statusPedido)
        {
            var metodo = "api/StatusPedido/";
            var objeto = ObjetoToJson(statusPedido);
            var retornoApi = ChamadaPost(metodo, objeto);

            if (retornoApi.Status == HttpStatusCode.OK)
                statusPedido = JsonConvert.DeserializeObject<StatusPedidoModel>(retornoApi.Objeto);

            return statusPedido.IdStatusPedido;
        }

        #endregion

        public LoginModel VerificarAcesso(string email, string senha)
        {
            var metodo = "api/login?email=" + email + "&senha=" + senha;
            LoginModel login = null;
            ClienteModel cliente = null;
            var retornoApi = ChamadaGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
            {
                login = JsonConvert.DeserializeObject<LoginModel>(retornoApi.Objeto);
                if (login != null)
                {
                    // Obter dados do Cliente
                    metodo = "api/Cliente/" + login.Id;
                    retornoApi = ChamadaGet(metodo);

                    if (retornoApi.Status == HttpStatusCode.OK)
                    {
                        cliente = JsonConvert.DeserializeObject<ClienteModel>(retornoApi.Objeto);
                        if (cliente != null)
                            login.Cliente = cliente;
                    }
                }
            }

            return login;
        }

        public List<PedidoModel> ObterPedidosCliente(int idCliente)
        {
            var metodo = "api/pedido/cliente/" + idCliente;
            List<PedidoModel> pedidos = null;
            List<PedidoModel> pedidosFinal = new List<PedidoModel>();
            List<StatusPedidoModel> statusPedido = null;
            List<ProdutoModel> produtos = null;
            
            var retornoApi = ChamadaGet(metodo);

            if (retornoApi.Status == HttpStatusCode.OK)
            {
                pedidos = JsonConvert.DeserializeObject<List<PedidoModel>>(retornoApi.Objeto);

                foreach (var pedido in pedidos)
                {
                   
                    // Obter StatusPedido
                    metodo = "api/StatusPedido/Pedido/" + pedido.Id;
                    retornoApi = ChamadaGet(metodo);

                    if (retornoApi.Status == HttpStatusCode.OK && retornoApi.Objeto != null)
                    {
                        statusPedido = JsonConvert.DeserializeObject<List<StatusPedidoModel>>(retornoApi.Objeto);
                        pedido.StatusPedido = statusPedido;
                    }

                    // Obter Produtos
                    metodo = "api/PedidoProdutos/Pedido/" + pedido.Id;
                    retornoApi = ChamadaGet(metodo);

                    if (retornoApi.Status == HttpStatusCode.OK && retornoApi.Objeto != null)
                    {
                        produtos = JsonConvert.DeserializeObject<List<ProdutoModel>>(retornoApi.Objeto);
                        pedido.Itens = produtos;
                    }

                    pedidosFinal.Add(pedido);
                }
            }

            return pedidosFinal;
        }
    }
}
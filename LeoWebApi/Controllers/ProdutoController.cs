using LeoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeoWebApi.Controllers
{
    public class ProdutoController : ApiController
    {
        Produto[] produtos = new Produto[]
        {
            new Produto { Id = 1,
                Nome = "Suco de Tomate",
                Descricao = "Alimentos",
                IdFornecedor = 1,
                IdProduto = 1,
                ValorFornecedor = 2000,
                ImgProduto = "TVSamsung.jpg",
                ValorVenda = 2200

            }

          
        };

        public IEnumerable<Produto> GetProdutos()
        {
            
            //var listaProduto = new List<Produto>();

            return ObterProdutos(null);            
        }

        private List<Produto> ObterProdutos(int? IdProduto)
        {
            Produto produto = new Produto();

            var listaProduto = new List<Produto>();

            produto.Id = 1;
            produto.Nome = "Notebook Dell Core I7 16 GB Ram";
            produto.Descricao = "Poderoso notebook excelente para desenvolvimento de aplicações e jogos.";
            produto.IdFornecedor = 1;
            produto.ValorFornecedor = 3000.00;
            produto.ImgProduto = "1.jpg";
            listaProduto.Add(produto);

            produto = new Produto();
            produto.Id = 2;
            produto.Nome = "Smartv Samsung 40 polegadas 4k";
            produto.Descricao = "Perfeita para assisstir futebol e filmes.";
            produto.IdFornecedor = 1;
            produto.ValorFornecedor = 2500.00;
            produto.ImgProduto = "2.jpg";
            listaProduto.Add(produto);

            produto = new Produto();
            produto.Id = 3;
            produto.Nome = "Celular Samsung S10 128 Gb";
            produto.Descricao = "Melhor Celular Android já fabribado.";
            produto.IdFornecedor = 1;
            produto.ValorFornecedor = 5000.00;
            produto.ImgProduto = "3.jpg";
            listaProduto.Add(produto);

            //if (!String.IsNullOrEmpty(Descricao))
            //    listaProduto = listaProduto.Where(x => x.Descricao.ToUpper().Trim().Contains(Descricao.ToUpper().Trim())).AsEnumerable().ToList();

            if (IdProduto.HasValue)
                listaProduto = listaProduto.Where(x => x.Id == IdProduto.Value).ToList();

            return listaProduto;
        }

        public Produto GetProdutoPorId(int id)
        {
            //var lista = GetProdutos(id);
            //return lista != null ? lista.FirstOrDefault() : null;

            //return produtos.FirstOrDefault();
            
            return ObterProdutos(id).FirstOrDefault();
        }
                
        //public IEnumerable<Produto> GetProdutosPorCategoria(int Id)
        //{
        //    return produtos.Where((p) => p.Id == Id);                
        //}
    }
}

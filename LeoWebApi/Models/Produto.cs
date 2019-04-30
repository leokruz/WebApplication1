using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeoWebApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int IdFornecedor { get; set; }
        public int IdProduto { get; set; }
        public double ValorFornecedor { get; set; }
        public string ImgProduto { get; set; }
        public int Quantidade { get; set; }
        public double ValorVenda { get;  set; }
        }
}
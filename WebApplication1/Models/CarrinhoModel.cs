using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CarrinhoModel
    {
        [Key]
        public int Id { get; set; }

        private List<ProdutoModel> _Itens = new List<ProdutoModel>();
        public List<ProdutoModel> Itens { get { return _Itens; } }

        public double ValorTotal { get { return _Itens.Sum(p => p.ValorVenda * p.Quantidade); } }

        public void AddItem(ProdutoModel produto)
        {
            _Itens.Add(produto);
        }
        public void Clear()
        {
            _Itens.Clear();
        }
        public void RemoveItem(int index)
        {
            _Itens.RemoveAt(index);
        }
    }
}
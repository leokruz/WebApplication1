using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
   
    public class PedidoItemModel : LogModel
    {
        public PedidoItemModel()
        {
            DataPedido = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
                
        public int IdPedido { get; set; }
                
        public int IdFornecedor { get; set; }
       
        public int IdProdutoFornecedor { get; set; }

        public string NomeProduto { get; set; }

        public string Imagem { get; set; }

        public double ValorFornecedor { get; set; }

        public double ValorVenda { get; set; }

        public DateTime DataPedido { get; set; }
    }

}

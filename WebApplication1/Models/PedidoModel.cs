using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
   
    public class PedidoModel : LogModel
    {
        [Key]
        public int Id { get; set; }
                
        public ClienteModel Cliente { get; set; }

        public int IdCliente { get; set; }

        public double Valor { get; set; }

        public int IdFormaPagamento { get; set; }

        public List<StatusPedidoModel> StatusPedido { get; set; }

        public List<ProdutoModel> Itens { get; set; }

    }
}

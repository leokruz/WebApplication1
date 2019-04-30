using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class StatusPedidoModel : LogModel
    {
        public StatusPedidoModel()
        {
            DataInclusao = DateTime.Now;
        }
        
        public int IdStatusPedido { get; set; }

        public int IdPedido { get; set; }
        public virtual PedidoModel Pedido { get; set; }

        [Required, StringLength(20)]
        public string DescStatus { get; set; }

        public DateTime DataInclusao { get; set; }

        
    }
}

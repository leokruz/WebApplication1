using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace LeoDatabase.Models
{
    [Table("StatusPedido")]
    public class StatusPedido
    {
        public StatusPedido()
        {
            DataInclusao = DateTime.Now;
        }


        [Key]
        public int IdStatusPedido { get; set; }

        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        public virtual Pedido Pedido { get; set; }

        [Required, StringLength(20)]
        public string DescStatus { get; set; }

        public DateTime DataInclusao { get; set; }

       
    }
}

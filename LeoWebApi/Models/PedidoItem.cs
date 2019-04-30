using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeoDatabase.Models
{
    [Table("PedidoItem")]
    public class PedidoItem : Log
    {
        public PedidoItem()
        {
            DataPedido = DateTime.Now;
        }

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }
        public virtual Pedido Pedido { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public int IdProduto { get; set; }

        [Required, StringLength(100)]
        public string NomeProduto { get; set; }

        public double ValorFornecedor { get; set; }

        public double ValorVenda { get; set; }

        public DateTime DataPedido { get; set; }
    }

}

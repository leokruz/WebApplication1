using CreateDb.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreateDb.Models
{
    [Table("Pedido")]
    public class Pedido : Log
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public virtual Cliente Cliente { get; set; }

        public double Valor { get; set; }

        [Required]
        public int IdFormaPagamento { get; set; }

        

    }
}

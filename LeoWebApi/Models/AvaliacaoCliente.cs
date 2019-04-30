using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace LeoDatabase.Models
{
    public class AvaliacaoCliente
    {
        public AvaliacaoCliente()
        {
            DataInclusao = DateTime.Now;
        }

        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32 Id { get; set; }

        [Required]
        public int Nota { get; set; }

        [Required, StringLength(150)]
        public string Descricao { get; set; }        

        public DateTime DataInclusao { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual PedidoItem PedidoItem { get; set; }
    }
}

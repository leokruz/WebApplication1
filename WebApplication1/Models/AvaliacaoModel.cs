using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace WebApplication1.Models
{
    public class AvaliacaoModel
    {
        [Key]
        public Int32 IdAvaliacao { get; set; }

        public int Nota { get; set; }

        public string Descricao { get; set; }        

        public DateTime DataInclusao { get; set; }

        public ClienteModel Cliente { get; set; }
        public PedidoItemModel PedidoItem { get; set; }
    }
}

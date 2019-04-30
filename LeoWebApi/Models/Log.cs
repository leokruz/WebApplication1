using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeoDatabase.Models
{
    public class Log
    {
        public Log()
        {
            DataAtualizacao = DateTime.Now;
        }

        [Required]
        public string UsuarioAtualizacao { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}

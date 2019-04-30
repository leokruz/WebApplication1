using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CreateDb.Model;

namespace CreateDb.Models
{
    [Table("Cliente")]
    public class Cliente : Log
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public long Cpf { get; set; }

        [Required, StringLength(1)]
        public string Sexo { get; set; }

        [Required, StringLength(20)]
        public string Telefone { get; set; }

        [Required, StringLength(80)]
        public string Endereco { get; set; }

        [Required, StringLength(8)]
        public string Cep { get; set; }

        public virtual Login Login { get; set; }
        
        public virtual List<Pedido> Pedidos { get; set; }
    }
}

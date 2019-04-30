using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50, ErrorMessage = "Informe o nome completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required, StringLength(1, ErrorMessage = "Informe o CPF")]
        public long Cpf { get; set; }

        [Required, StringLength(1, ErrorMessage = "Informe o sexo (M ou F)")]
        public string Sexo { get; set; }

        [Required, StringLength(20, ErrorMessage = "Informe um telefone")]
        public string Telefone { get; set; }

        public virtual LoginModel Login { get; set; }

        [Required, StringLength(50, ErrorMessage = "Informe um endereço")]
        public string Endereco { get; set; }

        [Required, StringLength(8)]
        public string Cep { get; set; }

        public virtual List<PedidoModel> Pedidos { get; set; }
    }
}

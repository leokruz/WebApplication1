using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    
    public class FornecedorModel
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(80, ErrorMessage = "Informe o nome do fornecedor")]
        public string Nome { get; set; }

        [Required, StringLength(14, ErrorMessage = "Informe o cpf ou cnpj")]
        public string CpfCnpj { get; set; }

        [Required, StringLength(50, ErrorMessage = "Informe a url do serviço")]
        public string URLApi { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        public virtual ICollection<PedidoModel> Pedidos { get; set; }
    }
}

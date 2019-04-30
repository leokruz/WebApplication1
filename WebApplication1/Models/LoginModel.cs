using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Models
{
    
    public class LoginModel
    {
        [Key, ForeignKey("Cliente")]
        public int Id { get; set; }

        [Required, StringLength(50, ErrorMessage = "Informe o email")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required, StringLength(100, ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [DisplayName("Senha")]
        public string Senha { get; set; }
                
        
        public int IdPerfil { get; set; }

        public virtual ClienteModel Cliente { get; set; }
    }
}

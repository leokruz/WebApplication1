using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeoFrontEnd.Models
{
    //[Table("Perfil")]
    public class PerfilModel
    {
        //[Key, Required]
        //public int Id { get; set; }

        //[Required, StringLength(20, ErrorMessage = "Informe o Perfil")]
        //public string Descricao { get; set; }
        public PerfilModel()
        {

        }

        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
    }
}

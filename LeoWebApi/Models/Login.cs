using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LeoDatabase.Models
{
    [Table("Login")]
    public class Login : Log
    {
        [Key, ForeignKey("Cliente")]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, StringLength(20)]
        public string Senha { get; set; }

        public int IdPerfil { get; set; }
                
        [Required]
        public virtual Cliente Cliente { get; set; }
    }
}

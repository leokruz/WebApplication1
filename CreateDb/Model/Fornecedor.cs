using CreateDb.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreateDb.Models
{
    [Table("Fornecedor")]
    public class Fornecedor : Log
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Nome { get; set; }

        [Required, StringLength(14)]
        public string CpfCnpj { get; set; }

        [Required, StringLength(50)]
        public string URLServico { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}

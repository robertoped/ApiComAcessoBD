using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Models
{
    public class TipoPessoa
    {
        [Key]
        public short Id { get; set; }
        public string Descricao { get; set; }
    }
}

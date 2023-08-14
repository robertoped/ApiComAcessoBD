using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Models
{
    public class TipoRegime
    {
        [Key]
        public short Id { get; set; }
        public string Descricao { get; set; }
    }
}

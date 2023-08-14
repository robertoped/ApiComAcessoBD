using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Models
{
    public class NivelFormacao
    {
        [Key]
        public short Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}

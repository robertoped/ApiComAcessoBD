using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Models
{
    public class UnidadeFederativa
    {
        [Key]
        public short Id { get; set; }
        public string Nome { get; set; }
        public string Capital { get; set; }
        public bool Ativo { get; set; }
    }
}

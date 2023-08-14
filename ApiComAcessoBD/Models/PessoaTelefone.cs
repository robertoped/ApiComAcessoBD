using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Models
{
    public class PessoaTelefone
    {
        [Key]
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public short IdTipoTelefone { get; set; }
        public string Numero { get; set; }
    }
}

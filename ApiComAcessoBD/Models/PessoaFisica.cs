using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiComAcessoBD.Models
{
    public class PessoaFisica
    {
        [Key]
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public short IdNivelFormacao { get; set; }
        public short IdEstadoCivil { get; set; }
        public short IdNaturalidade { get; set; }
        public DateTime DataNascimento { get; set;}
        public string Filiacao1 { get; set; }
        public string Filiacao2 { get; set; }
    }
}

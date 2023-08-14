using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiComAcessoBD.Models
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }
        public short IdTipoPessoa { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public PessoaFisica? PessoaFisica { get; set; }
        public PessoaJuridica? PessoaJuridica { get; set; }
        public IEnumerable<PessoaTelefone> PessoaTelefones { get; set; }
        public IEnumerable<PessoaEndereco> PessoaEnderecos { get; set; }
    }
}

using ApiComAcessoBD.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class PessoaDto
    {
        [Required(ErrorMessage = "O tipo de pessoa é obrigatório.")]
        public short IdTipoPessoa { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [StringLength(100)]
        public string Email { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public bool Ativo { get; set; }

        public PessoaFisicaDto? PessoaFisica { get; set; }

        public PessoaJuridicaDto? PessoaJuridica { get; set; }

        public IEnumerable<PessoaTelefoneDto> PessoaTelefones { get; set; }

        public IEnumerable<PessoaEnderecoDto> PessoaEnderecos { get; set; }
    }
}

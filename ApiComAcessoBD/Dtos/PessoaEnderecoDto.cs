using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class PessoaEnderecoDto
    {
        [Required(ErrorMessage = "O Cep é obrigatório.")]
        [StringLength(8)]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório.")]
        [StringLength(100)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        [StringLength(10)]
        public string Numero { get; set; }

        [StringLength(30)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório.")]
        [StringLength(50)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Id. Unidade Federativa é obrigatório.")]
        public short IdUnidadeFederativa { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50)]
        public string Cidade { get; set; }

        public bool Principal { get; set; }

        public bool Entrega { get; set; }

        public bool Cobranca { get; set; }

        public bool Correspondencia { get; set; }
    }
}

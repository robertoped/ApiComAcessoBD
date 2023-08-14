using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Models
{
    public class PessoaEndereco
    {
        [Key]
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public short IdUnidadeFederativa { get; set; }
        public string Cidade { get; set; }
        public bool Principal { get; set; }
        public bool Entrega { get; set; }
        public bool Cobranca { get; set; }
        public bool Correspondencia { get; set; }
    }
}

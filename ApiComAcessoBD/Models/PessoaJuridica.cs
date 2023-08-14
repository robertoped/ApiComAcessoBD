using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Models
{
    public class PessoaJuridica
    {
        [Key]
        public int IdPessoa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public DateTime DataFundacao { get; set;}
        public short IdTipoRegime { get; set; }
    }
}

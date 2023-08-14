using ApiComAcessoBD.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class PessoaJuridicaDto
    {
        [Required(ErrorMessage = "O razão social é obrigatória.")]
        [StringLength(150)]
        public string RazaoSocial { get; set; }

        [StringLength(100)]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(14)]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "A inscrição estadual é obrigatória.")]
        [StringLength(45)]
        public string InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "A inscrição municipal é obrigatória.")]
        [StringLength(45)]
        public string InscricaoMunicipal { get; set; }

        [Required(ErrorMessage = "A data de fundação é obrigatória.")]
        public DateTime DataFundacao { get; set;}

        [Required(ErrorMessage = "O tipo de regime é obrigatório.")]
        [Range(1, 3, ErrorMessage = "1-Lucro Presumido, 2-Lucro Real e 3-Simples Nacional")]
        public short IdTipoRegime { get; set; }
    }
}

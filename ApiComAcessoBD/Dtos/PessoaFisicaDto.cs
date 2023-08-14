using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class PessoaFisicaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11)]
        public string Cpf { get; set; }

        [Range(1, 6, ErrorMessage = "1-Ensino Médio, 2-Curso Técnico, 3-Graduação, 4-Pós Graduação, 5-Mestrado, 6-Doutorado")]
        public short IdNivelFormacao { get; set; }

        [Required(ErrorMessage = "O estado civil é obrigatório.")]
        public short IdEstadoCivil { get; set; }

        [Required(ErrorMessage = "A naturalidade é obrigatória.")]
        public short IdNaturalidade { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set;}

        [Required(ErrorMessage = "A filiação1 é obrigatória.")]
        [StringLength(150)]
        public string Filiacao1 { get; set; }

        [Required(ErrorMessage = "A filia~ção é obrigatória.")]
        [StringLength(150)]
        public string Filiacao2 { get; set; }
    }
}

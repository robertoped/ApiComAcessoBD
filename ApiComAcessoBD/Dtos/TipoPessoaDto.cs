using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class TipoPessoaDto
    {
        [Required(ErrorMessage = "A descrição do tipo de pessoa é obrigatória.")]
        [StringLength(15)]
        public string Descricao { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class TipoTelefoneDto
    {
        [Required(ErrorMessage = "A descrição do telefone é obrigatória.")]
        [StringLength(13)]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}

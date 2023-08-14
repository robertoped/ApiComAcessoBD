using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class NivelFormacaoDto
    {
        [Required(ErrorMessage = "A descrição do nível formação é obrigatória.")]
        [StringLength(13)]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class EstadoCivilDto
    {
        [Required(ErrorMessage = "A descrição do estado civil é obrigatória.")]
        [StringLength(13)]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }
    }
}

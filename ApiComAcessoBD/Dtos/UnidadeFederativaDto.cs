using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class UnidadeFederativaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(19)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A capital é obrigatória.")]
        [StringLength(14)]
        public string Capital { get; set; }

        public bool Ativo { get; set; }
    }
}

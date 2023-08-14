using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class TipoRegimeDto
    {
        [Required(ErrorMessage = "O tipo de regime é obrigatório.")]
        [Range(1, 3, ErrorMessage = "1-Lucro Presumido, 2-Lucro Real e 3-Simples Nacional")]
        public short Id { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ApiComAcessoBD.Dtos
{
    public class PessoaTelefoneDto
    {
        [Required(ErrorMessage = "O tipo de telefone é obrigatório.")]
        public short IdTipoTelefone { get; set; }

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [StringLength(15)]
        public string Numero { get; set; }
    }
}

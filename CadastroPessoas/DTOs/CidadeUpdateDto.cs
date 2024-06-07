using System.ComponentModel.DataAnnotations;
using CadastroPessoas.Validations;

namespace CadastroPessoas.DTOs
{
    public class CidadeUpdateDto
    {
        [Required(ErrorMessage = "Preencher campo cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencher campo estado.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Digite a UF do estado corretamente.")]
        [NoNumbers]
        public string Estado { get; set; }
    }
}



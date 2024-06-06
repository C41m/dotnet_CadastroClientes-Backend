using CadastroPessoas.Enums;
using CadastroPessoas.Models;
using System.ComponentModel.DataAnnotations;

namespace CadastroPessoas.DTOs
{
    public class ClienteCreateDto
    {
        [Required(ErrorMessage ="Preencha o campo nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo sobrenome!")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo sexo!")]
        public SexoEnum Sexo { get; set; }

        [Required(ErrorMessage = "Preencha o campo data de nascimento!")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo de ativo!")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Preencha o campo de cidade!")]
        public int CidadeId { get; set; }
    }
}

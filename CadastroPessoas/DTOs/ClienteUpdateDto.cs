using CadastroPessoas.Enums;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CadastroPessoas.DTOs
{
    public class ClienteUpdateDto
    {
        [Required(ErrorMessage = "Preencha o campo ID!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome!")]
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


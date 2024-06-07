using CadastroPessoas.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CadastroPessoas.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencher campo cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencher campo estado.")]
        [StringLength(2, ErrorMessage = "Digite apenas a sigla do estado.")]
        [NoNumbers(ErrorMessage = "O campo Estado não pode conter números")]
        public string Estado { get; set; }

        [JsonIgnore]
        public ICollection<ClienteModel>? Clientes { get; set; }


    }
}

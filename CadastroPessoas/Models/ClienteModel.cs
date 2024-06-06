using CadastroPessoas.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastroPessoas.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public SexoEnum Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

        public int Idade { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();

        // Chave estrangeira
        public int CidadeId { get; set; }

        // Propriedade de navegação
        public CidadeModel Cidade { get; set; }
    }
}

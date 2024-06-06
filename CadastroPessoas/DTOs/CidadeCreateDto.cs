using System.ComponentModel.DataAnnotations;

namespace CadastroPessoas.DTOs
{
    public class CidadeCreateDto
    {
        [Required(ErrorMessage = "Preencher campo cidade.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencher campo estado.")]
        [StringLength(2, ErrorMessage = "Digite apenas a sigla do estado.")]
        [NoNumbers]
        public string Estado { get; set; }
    }
}


// Validações personalizadas
public class NoNumbersAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string estado = value.ToString();
            if (ContainsNumbers(estado))
            {
                return new ValidationResult("O campo Estado não pode conter números.");
            }
        }
        return ValidationResult.Success;
    }

    private bool ContainsNumbers(string value)
    {
        foreach (char c in value)
        {
            if (char.IsDigit(c))
            {
                return true;
            }
        }
        return false;
    }
}
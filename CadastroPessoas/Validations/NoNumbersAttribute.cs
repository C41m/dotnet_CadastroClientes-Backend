using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroPessoas.Validations
{
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
}

namespace CadastroPessoas.Exceptions.CidadeExceptions
{
    public class SemCidadeCadastradasException : Exception
    {
        public SemCidadeCadastradasException() : base("Sem cidades cadastradas.")
        {

        }
    }
}

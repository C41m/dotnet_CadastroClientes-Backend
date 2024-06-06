namespace CadastroPessoas.Exceptions.CidadeExceptions
{
    public class CidadeNaoLocalizadaEstadoException : Exception
    {
        public string EstadoNome { get; private set; }
        public CidadeNaoLocalizadaEstadoException(string estadoNome) : base($"Cidades de {estadoNome} não localizadas.")
        {
            EstadoNome = estadoNome;
        }
    }
}

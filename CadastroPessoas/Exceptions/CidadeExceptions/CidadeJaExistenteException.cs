namespace CadastroPessoas.Exceptions.CidadeExceptions
{
    public class CidadeJaExistenteException : Exception
    {
        public int? CidadeId { get; private set; }
        public string CidadeNome { get; private set; }
        public string EstadoNome { get; private set; }
        public CidadeJaExistenteException(string cidadeNome, string estadoNome, int? cidadeId = null) : base($"Localidade {cidadeId} - {cidadeNome} - {estadoNome} já existente.")
        {
            CidadeId = cidadeId;
            CidadeNome = cidadeNome;
            EstadoNome = estadoNome;
        }
    }
}

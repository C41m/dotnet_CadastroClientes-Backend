namespace CadastroPessoas.Exceptions.CidadeExceptions
{
    public class CidadeNaoLocalizadaException : Exception
    {
        public int? CidadeId { get; private set; }

        public string? CidadeNome { get; private set; }
        public CidadeNaoLocalizadaException(int? cidadeId, string? cidadeNome) : base($"Cidade {cidadeId}{cidadeNome} não localizada")
        {
            CidadeId = cidadeId;
            CidadeNome = cidadeNome;
        }
    }
}

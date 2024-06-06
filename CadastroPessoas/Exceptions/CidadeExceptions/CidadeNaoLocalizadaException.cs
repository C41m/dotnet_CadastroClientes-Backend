namespace CadastroPessoas.Exceptions.CidadeExceptions
{
    public class CidadeNaoLocalizadaException : Exception
    {
        public int CidadeId { get; private set; }
        public CidadeNaoLocalizadaException(int cidadeId) : base($"Cidade com ID: {cidadeId} não localizada")
        {
            CidadeId = cidadeId;
        }
    }
}

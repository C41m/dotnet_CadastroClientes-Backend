namespace CadastroPessoas.Exceptions.CidadeExceptions
{
    public class CidadeComClienteException : Exception
    {
        public int CidadeId { get; private set; }
        public CidadeComClienteException(int cidadeId) : base($"Cidade com ID: {cidadeId} não pode ser excluído por ser associado a cliente(s).")
        {
            CidadeId = cidadeId;
        }
    }
}

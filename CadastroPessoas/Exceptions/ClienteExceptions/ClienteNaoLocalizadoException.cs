namespace CadastroPessoas.Exceptions.ClienteExceptions
{
    public class ClienteNaoLocalizadoException : Exception
    {
        public int? ClienteId { get; private set; }
        public string? ClienteNome {  get; private set; }
        public string? ClienteSobrenome { get; private set; }

        public ClienteNaoLocalizadoException(int? clienteId = null, string? clienteNome = null, string? clienteSobrenome = null) : base($"Cliente {clienteId} {clienteNome} {clienteSobrenome} não localizado.")
        {
            ClienteId = clienteId;
            ClienteSobrenome = clienteSobrenome;
            ClienteNome = clienteNome;
        }
    }
}




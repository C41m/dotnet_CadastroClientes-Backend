using CadastroPessoas.DataContext;
using CadastroPessoas.Exceptions.CidadeExceptions;
using CadastroPessoas.Exceptions.ClienteExceptions;
using CadastroPessoas.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoas.Service.ClienteService
{
    public class ClienteService : IClienteInterface
    {
        private readonly ApplicationDbContext _context;
        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ClienteModel>> GetClientes()
        {
            try
            {
                var clientes = await _context.Clientes.Include(c => c.Cidade).ToListAsync();

                return clientes;

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro ao consultar clientes: {ex.Message}");
            }

        }

        public async Task<List<ClienteModel>> CreateClient(ClienteModel novoCliente)
        {
            try
            {
                var cidade = await _context.Cidades.FindAsync(novoCliente.CidadeId);

                if (cidade == null)
                {
                    throw new CidadeNaoLocalizadaException(novoCliente.CidadeId, null);
                }

                novoCliente.Idade = CalcularIdade(novoCliente.DataNascimento);
                _context.Clientes.Add(novoCliente);
                await _context.SaveChangesAsync();

                var cliente = await _context.Clientes.Include(c => c.Cidade).ToListAsync();

                return cliente;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClienteModel> GetClienteById(int id)
        {
            try
            {
                var cliente = await _context.Clientes
                    .Include(c => c.Cidade)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (cliente == null)
                {
                    throw new ClienteNaoLocalizadoException(id);
                }

                return cliente;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ClienteModel>> GetClientesByNomeSobrenome(string nomeCliente, string sobrenomeCliente)
        {

            try
            {
                var clienteBuscado = _context.Clientes.Include(c => c.Cidade).AsQueryable();

                if (!string.IsNullOrEmpty(nomeCliente))
                {
                    clienteBuscado = clienteBuscado.Where(x => x.Nome.Contains(nomeCliente));
                }

                if (!string.IsNullOrEmpty(sobrenomeCliente))
                {
                    clienteBuscado = clienteBuscado.Where(x => x.Sobrenome.Contains(sobrenomeCliente));
                }

                var clientes = await clienteBuscado.ToListAsync();

                if (clientes == null || !clientes.Any())
                {
                    throw new ClienteNaoLocalizadoException(null, nomeCliente, sobrenomeCliente);
                }
                else
                {
                    return clientes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public async Task<List<ClienteModel>> UpdateCliente(ClienteModel editadoCliente)
        {
            try
            {
                // Verifica se o cliente existe no banco.
                var client = await _context.Clientes.FindAsync(editadoCliente.Id);
                if (client == null)
                {
                    throw new ClienteNaoLocalizadoException(editadoCliente.Id);
                }

                // Verifica se a cidade existe no banco.
                var cidadeExistente = await _context.Cidades.FindAsync(editadoCliente.CidadeId);
                if (cidadeExistente == null)
                {
                    throw new CidadeNaoLocalizadaException(editadoCliente.CidadeId, null);
                }

                // Atualiza cliente com os novos valores.
                client.Nome = editadoCliente.Nome;
                client.Sobrenome = editadoCliente.Sobrenome;
                client.Sexo = editadoCliente.Sexo;
                client.DataNascimento = editadoCliente.DataNascimento;
                client.Ativo = editadoCliente.Ativo;
                client.DataAlteracao = DateTime.Now.ToLocalTime();
                client.CidadeId = editadoCliente.CidadeId;
                client.Idade = CalcularIdade(editadoCliente.DataNascimento);

                await _context.SaveChangesAsync();

                // Lista com todos os clientes.
                var cliente = await _context.Clientes.Include(c => c.Cidade).ToListAsync();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ClienteModel>> DeleteCliente(int id)
        {
            try
            {
                // Verifica se o cliente existe no banco.
                var clientDeleted = await _context.Clientes.FindAsync(id);
                if (clientDeleted == null)
                {
                    throw new ClienteNaoLocalizadoException(id);
                }

                // Remove cliente.
                _context.Clientes.Remove(clientDeleted);
                await _context.SaveChangesAsync();

                // Lista com os clientes restantes.
                var clientes = _context.Clientes.ToList();

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // Função para calcular a idade
        private int CalcularIdade(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - dataNascimento.Year;

            if (dataNascimento.Date > hoje.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }

    }

}

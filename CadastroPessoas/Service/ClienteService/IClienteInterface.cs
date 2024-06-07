using CadastroPessoas.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoas.Service.ClienteService
{
    public interface IClienteInterface
    {
        Task<List<ClienteModel>> GetClientes();
        Task<List<ClienteModel>> CreateClient(ClienteModel novoCliente);
        Task<ClienteModel> GetClienteById(int id);
        Task<List<ClienteModel>> GetClientesByNomeSobrenome(string nomeCliente, string sobrenomeCliente);
        Task<List<ClienteModel>> UpdateCliente(int id, ClienteModel editadoCliente);
        Task<List<ClienteModel>> DeleteCliente(int id);
    }
}

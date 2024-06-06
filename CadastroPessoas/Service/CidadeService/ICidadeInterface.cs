using CadastroPessoas.Models;

namespace CadastroPessoas.Service.CidadeService
{
    public interface ICidadeInterface
    {
        Task<List<CidadeModel>> GetCidades();

        Task<List<CidadeModel>> CreateCidade(CidadeModel novaCidade);

        Task<CidadeModel> GetCidadeById(int id);

        Task<List<CidadeModel>> UpdateCidade(CidadeModel editadoCidade);

        Task<List<CidadeModel>> DeleteCidade(int id);

        Task<List<CidadeModel>> GetCidadeByEstado(string estado);
    }
}

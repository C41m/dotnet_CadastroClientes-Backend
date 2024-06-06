using CadastroPessoas.DataContext;
using CadastroPessoas.Exceptions.CidadeExceptions;
using CadastroPessoas.Models;
using CadastroPessoas.Service.CidadeService;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoas.Service.CidadesService
{
    public class CidadeService : ICidadeInterface
    {
        private readonly ApplicationDbContext _context;

        public CidadeService(ApplicationDbContext context)

        {
            _context = context;
        }

        public async Task<List<CidadeModel>> CreateCidade(CidadeModel novaCidade)
        {
            try
            {
                // Verificar se existe o mesmo registro já cadastrado
                var cidadeExistente = await _context.Cidades
                    .FirstOrDefaultAsync(c => c.Cidade == novaCidade.Cidade && c.Estado == novaCidade.Estado);

                if (cidadeExistente != null)
                {
                    throw new CidadeJaExistenteException(cidadeExistente.Cidade, cidadeExistente.Estado, cidadeExistente.Id);
                }

                _context.Add(novaCidade);
                await _context.SaveChangesAsync();

                var cidades = await _context.Cidades.ToListAsync();

                return cidades;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CidadeModel>> DeleteCidade(int id)
        {
            try
            {
                // Verificar se existe a cidade
                var cidades = await _context.Cidades.FirstOrDefaultAsync(x => x.Id == id);
                if (cidades == null)
                {
                    throw new CidadeNaoLocalizadaException(id);
                }

                // Verificar se existem clientes associados à cidade
                var clientesNaCidade = await _context.Clientes.AnyAsync(x => x.CidadeId == id);
                if (clientesNaCidade)
                {    
                    throw new CidadeComClienteException(id);
                }

                _context.Cidades.Remove(cidades);
                await _context.SaveChangesAsync();

                var cidadesList = await _context.Cidades.ToListAsync();

                return cidadesList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CidadeModel> GetCidadeById(int id)
        {
            try
            {
                var cidade = await _context.Cidades.FirstOrDefaultAsync(x => x.Id == id);

                if (cidade == null)
                {
                    throw new CidadeNaoLocalizadaException(id);
                }

                return cidade;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CidadeModel>> GetCidades()
        {

            try
            {
                var cidades = await _context.Cidades.ToListAsync();

                if (cidades.Count == 0)
                {
                    throw new SemCidadeCadastradasException();
                }

                return cidades;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<CidadeModel>> UpdateCidade(CidadeModel editadoCidade)
        {
            {
                try
                {
                    var cidade = await _context.Cidades.AsNoTracking().FirstOrDefaultAsync(x => x.Id == editadoCidade.Id);

                    if (cidade == null)
                    {
                        throw new CidadeNaoLocalizadaException(editadoCidade.Id);
                    }

                    var cidadeExistente = await _context.Cidades
                        .FirstOrDefaultAsync(c => c.Cidade == editadoCidade.Cidade && c.Estado == editadoCidade.Estado);

                    if (cidadeExistente != null)
                    {
                        throw new CidadeJaExistenteException(editadoCidade.Cidade, editadoCidade.Estado);
                    }

                    _context.Cidades.Update(editadoCidade);
                    await _context.SaveChangesAsync();

                    var cidades = await _context.Cidades.ToListAsync();

                    return cidades;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
    ;
        }

        public async Task<List<CidadeModel>> GetCidadeByEstado(string estado)
        {
            try
            {
                var cidades = await _context.Cidades.Where(x => x.Estado == estado).ToListAsync();

                if (cidades.Count == 0)
                { 
                    throw new CidadeNaoLocalizadaEstadoException(estado);
                }

                return cidades;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


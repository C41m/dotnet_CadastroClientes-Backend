using CadastroPessoas.DTOs;
using CadastroPessoas.Exceptions.CidadeExceptions;
using CadastroPessoas.Models;
using CadastroPessoas.Service.CidadeService;
using Microsoft.AspNetCore.Mvc;

namespace CadastroPessoas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeInterface _cidadeInterface;

        public CidadeController(ICidadeInterface CidadeController)
        {
            _cidadeInterface = CidadeController;
        }


        [HttpGet]
        public async Task<ActionResult<List<CidadeModel>>> GetCidades()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cidade = await _cidadeInterface.GetCidades();
                return Ok(cidade);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CidadeModel>> GetCidadeById(int id)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var cidade = await _cidadeInterface.GetCidadeById(id);
                return Ok(cidade);
            }

            catch (CidadeNaoLocalizadaException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("estado/{estado}")]
        public async Task<ActionResult<CidadeModel>> GetCidadeByEstado(string estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cidadesGetByEstado = await _cidadeInterface.GetCidadeByEstado(estado);
                return Ok(cidadesGetByEstado);
            }

            catch (CidadeNaoLocalizadaEstadoException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("cidade/{cidade}")]
        public async Task<ActionResult<CidadeModel>> GetCidadeByName(string cidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var cidades = await _cidadeInterface.GetCidadeByName(cidade);
                return Ok(cidades);
            }

            catch (CidadeNaoLocalizadaEstadoException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPost]
        public async Task<ActionResult<List<CidadeModel>>> CreateCidade(CidadeCreateDto newCidadeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCidade = new CidadeModel
            {
                Cidade = newCidadeDto.Cidade,
                Estado = newCidadeDto.Estado,
            };

            try
            {
                var cidades = await _cidadeInterface.CreateCidade(newCidade);
                return Ok(cidades);
            }
            catch (CidadeJaExistenteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult<List<CidadeModel>>> UpdateCidade(CidadeUpdateDto newUpdateCidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updateCidade = new CidadeModel
            {
                Id = newUpdateCidade.Id,
                Cidade = newUpdateCidade.Cidade,
                Estado = newUpdateCidade.Estado
            };

            try
            {
                var cidades = await _cidadeInterface.UpdateCidade(updateCidade);
                return Ok(cidades);
            }

            catch (CidadeNaoLocalizadaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CidadeJaExistenteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<ActionResult<List<CidadeModel>>> DeleteCidade(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var deleteCidade = await _cidadeInterface.DeleteCidade(id);
                return Ok(deleteCidade);

            }
            catch (CidadeNaoLocalizadaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (CidadeComClienteException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

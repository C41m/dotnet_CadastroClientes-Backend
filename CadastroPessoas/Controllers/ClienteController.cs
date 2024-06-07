using CadastroPessoas.DTOs;
using CadastroPessoas.Exceptions.CidadeExceptions;
using CadastroPessoas.Exceptions.ClienteExceptions;
using CadastroPessoas.Models;
using CadastroPessoas.Service.ClienteService;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace CadastroPessoas.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteInterface _clienteInterface;

        public ClienteController(IClienteInterface clienteInterface)
        {
            _clienteInterface = clienteInterface;
        }


        // Consultar todos clientes
        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> GetClientes()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var clientes = await _clienteInterface.GetClientes();

                return Ok(clientes);
            }

            catch (DbException ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("FindById/{id}")]
        public async Task<ActionResult<ClienteModel>> GetClienteById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cliente = await _clienteInterface.GetClienteById(id);
                return Ok(cliente);
            }
            catch (ClienteNaoLocalizadoException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("FindByName")]
        public async Task<ActionResult<List<ClienteModel>>> GetClientesByNomeSobrenome(string? nome, string? sobrenome)
        {
            try
            {
                var cliente = await _clienteInterface.GetClientesByNomeSobrenome(nome, sobrenome);
                return Ok(cliente);
            }
            catch (ClienteNaoLocalizadoException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ClienteModel>> CreateCliente(ClienteCreateDto novoClienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var novoCliente = new ClienteModel
            {
                Nome = novoClienteDto.Nome,
                Sobrenome = novoClienteDto.Sobrenome,
                Sexo = novoClienteDto.Sexo,
                DataNascimento = novoClienteDto.DataNascimento,
                Ativo = novoClienteDto.Ativo,
                CidadeId = novoClienteDto.CidadeId,
            };

            try
            {
                var cliente = await _clienteInterface.CreateClient(novoCliente);

                return Ok(cliente);
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

        [HttpPut]
        public async Task<ActionResult<List<ClienteModel>>> UpdateCliente(ClienteUpdateDto editadoClienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var editadoCliente = new ClienteModel
            {
                Id = editadoClienteDto.Id,
                Nome = editadoClienteDto.Nome,
                Sobrenome = editadoClienteDto.Sobrenome,
                Sexo = editadoClienteDto.Sexo,
                DataNascimento = editadoClienteDto.DataNascimento,
                Ativo = editadoClienteDto.Ativo,
                CidadeId = editadoClienteDto.CidadeId,
            };

            try
            {
                var cliente = await _clienteInterface.UpdateCliente(editadoCliente);

                return Ok(cliente);
            }
            catch (ClienteNaoLocalizadoException ex)
            {
                return NotFound(ex.Message);
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

        [HttpDelete]
        public async Task<ActionResult<List<ClienteModel>>> DeleteCliente(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cliente = await _clienteInterface.DeleteCliente(id);
                return Ok(cliente);

            }
            catch (ClienteNaoLocalizadoException ex)
            {
                return NotFound(ex.Message);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}

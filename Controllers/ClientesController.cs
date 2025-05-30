using API.Data;
using DapperWebAPI.Data;
using DapperWebAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepo;
        public ClientesController(IClienteRepository tarefaRepo)
        {
            _clienteRepo = tarefaRepo;
        }
        [HttpGet]
        [Route("Clientes")]
        public async Task<IActionResult> GetClientesAsync()
        {
            var result = await _clienteRepo.GetClientesAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("cliente/{id}")]
        public async Task<IActionResult> GetTodoItemByIdAsync(int id)
        {
            var tarefa = await _clienteRepo.GetClienteByIdAsync(id);
            return Ok(tarefa);
        }
        [HttpPut]
        [Route("atualizarCliente")]
        public async Task<IActionResult> UpdateTodoStatusAsync(Cliente atualizaCliente)
        {
            var result = await _clienteRepo.UpdateClienteAsync(atualizaCliente);
            return Ok(result);
        }
        [HttpGet]
        [Route("clientes/{parametro}/{campo}")]
        public async Task<IActionResult> GetTodoItemByIdAsync(int parametro, string campo)
        {
            var produtos = await _clienteRepo.GetClienteSearch(parametro, campo);
            return Ok(produtos);
        }

        [HttpPost]
        [Route("criarcliente")]
        public async Task<IActionResult> SaveAsync(Cliente novoCliente)
        {
            var result = await _clienteRepo.SaveAsync(novoCliente);
            return Ok(result);
        }
        [HttpDelete]
        [Route("deletaCliente/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var resultado = await _clienteRepo.DeleteAsync(id);
            return Ok(resultado);
        }
    }
}
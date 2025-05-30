using DapperWebAPI.Data;
using DapperWebAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepo;
        public ProdutosController(IProdutoRepository tarefaRepo)
        {
            _produtoRepo = tarefaRepo;
        }
        [HttpGet]
        [Route("Produtos")]
        public async Task<IActionResult> GetClientesAsync()
        {
            var result = await _produtoRepo.GetProdutosAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("produto/{id}")]
        public async Task<IActionResult> GetTodoItemByIdAsync(int id)
        {
            var produto = await _produtoRepo.GetProdutoByIdAsync(id);
            return Ok(produto);
        }
        [HttpGet]
        [Route("produtos/{campo}")]
        public async Task<IActionResult> GetTodoItemByIdAsync(string campo)
        {
            var produtos = await _produtoRepo.GetProdutoSearch(campo);
            return Ok(produtos);
        }
        [HttpPost]
        [Route("criarProduto")]
        public async Task<IActionResult> SaveAsync(Produto novoProduto)
        {
            var result = await _produtoRepo.SaveAsync(novoProduto);
            return Ok(result);
        }
        [HttpPut]
        [Route("atualizarProduto")]
        public async Task<IActionResult> UpdateTodoStatusAsync(Produto atualizaProduto)
        {
            var result = await _produtoRepo.UpdateProdutoAsync(atualizaProduto);
            return Ok(result);
        }
        [HttpDelete]
        [Route("deletaProduto/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var resultado = await _produtoRepo.DeleteAsync(id);
            return Ok(resultado);
        }
    }
}
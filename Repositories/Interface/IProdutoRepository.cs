using DapperWebAPI.Data;

namespace DapperWebAPI.Repositories.Interface
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> GetProdutosAsync();
        Task<Produto> GetProdutoByIdAsync(int id);
        Task<List<Produto>> GetProdutoSearch(string campo);
        Task<int> SaveAsync(Produto novoProduto);
        Task<int> UpdateProdutoAsync(Produto atualizaProduto);
        Task<int> DeleteAsync(int id);
    }
}

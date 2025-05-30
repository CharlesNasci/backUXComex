using DapperWebAPI.Data;

namespace DapperWebAPI.Repositories.Interface
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<int> SaveAsync(Cliente novoCliente);
        Task<List<Cliente>> GetClienteSearch(int parametro, string campo);

        Task<int> UpdateClienteAsync(Cliente atualizaCliente);
        Task<int> DeleteAsync(int id);
    }
}

using DapperWebAPI.Data;

namespace DapperWebAPI.Repositories.Interface
{
    public interface IPedidoRepository
    {
        Task<List<Pedido>> GetPedidosAsync();
        Task<Pedido> GetPedidoByIdAsync(int id);
        Task<int> SaveAsync(Pedido novoCliente);
        Task<int> UpdatePedidoAsync(Pedido atualizaPedido);
        Task<int> DeleteAsync(int id);
    }
}

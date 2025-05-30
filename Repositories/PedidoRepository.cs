using API.Data;
using Dapper;
using DapperWebAPI.Data;
using DapperWebAPI.Repositories.Interface;
namespace API.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private DbSession _db;
        public PedidoRepository(DbSession dbSession)
        {
            _db = dbSession;
        }
        public async Task<List<Pedido>> GetPedidosAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM Pedido";
                List<Pedido> pedidos = (await conn.QueryAsync<Pedido>(sql: query)).ToList();
                return pedidos;
            }
        }
        public async Task<Pedido> GetPedidoByIdAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM Pedido WHERE Id = @id";
                Pedido cliente = await conn.QueryFirstOrDefaultAsync<Pedido>(sql: query, param: new { id });
                return cliente;
            }
        }
        public async Task<int> SaveAsync(Pedido novoPedido)
        {
            using (var conn = _db.Connection)
            {
                string command = @"NSERT INTO Pedido(nome, email, telefone, dataCadastro)
    		VALUES(@nome, @email, @telefone, GETDATE())";
                var result = await conn.ExecuteAsync(sql: command, param: novoPedido);
                return result;
            }
        }
        public async Task<int> UpdatePedidoAsync(Pedido atualizaPedido)
        {
            using (var conn = _db.Connection)
            {
                string command = @"
    		     UPDATE Pedido SET nome = @nome, email = @email, telefone = @telefone WHERE Id = @Id";
                var result = await conn.ExecuteAsync(sql: command, param: atualizaPedido);
                return result;
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string command = @"DELETE FROM Pedido WHERE Id = @id";
                var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                return resultado;
            }
        }
    }

}

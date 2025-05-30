using API.Data;
using Dapper;
using DapperWebAPI.Data;
using DapperWebAPI.Repositories.Interface;
namespace API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private DbSession _db;
        public ClienteRepository(DbSession dbSession)
        {
            _db = dbSession;
        }
        public async Task<List<Cliente>> GetClientesAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM Cliente";
                List<Cliente> clientes = (await conn.QueryAsync<Cliente>(sql: query)).ToList();
                return clientes;
            }
        }
        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM Cliente WHERE Id = @id";
                Cliente cliente = await conn.QueryFirstOrDefaultAsync<Cliente>(sql: query, param: new { id });
                return cliente;
            }
        }
        public async Task<List<Cliente>> GetClienteSearch(int parametro, string campo)
        {
            using (var conn = _db.Connection)
            {
                // Lista de campos permitidos para busca
                var paramAux = parametro == 0 ? "nome" : "email";

                string query = $@"
                               SELECT ID, Nome, email, telefone, dataCadastro 
                                FROM Cliente 
                                WHERE {paramAux} LIKE @campo COLLATE Latin1_General_CI_AI";

                var paramCampo = new { campo = $"%{campo}%" };
                var clientes = (await conn.QueryAsync<Cliente>(query, paramCampo)).ToList();
                return clientes;
            }
        }
        public async Task<int> SaveAsync(Cliente novoCliente)
        {
            using (var conn = _db.Connection)
            {
                string command = @"INSERT INTO Cliente(nome, email, telefone, dataCadastro)
    		VALUES(@nome, @email, @telefone,@dataCadastro)";
                var result = await conn.ExecuteAsync(sql: command, param: novoCliente);
                return result;
            }
        }
        public async Task<int> UpdateClienteAsync(Cliente atualizaCliente)
        {
            using (var conn = _db.Connection)
            {
                string command = @"
    		     UPDATE Cliente SET nome = @nome, email = @email, telefone = @telefone, dataCadastro = @dataCadastro WHERE Id = @Id";
                var result = await conn.ExecuteAsync(sql: command, param: atualizaCliente);
                return result;
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string command = @"DELETE FROM Cliente WHERE Id = @id";
                var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                return resultado;
            }
        }
    }

}

using API.Data;
using Dapper;
using DapperWebAPI.Data;
using DapperWebAPI.Repositories.Interface;
namespace API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private DbSession _db;
        public ProdutoRepository(DbSession dbSession)
        {
            _db = dbSession;
        }
        public async Task<List<Produto>> GetProdutosAsync()
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM Produto";
                List<Produto> produtos = (await conn.QueryAsync<Produto>(sql: query)).ToList();
                return produtos;
            }
        }
        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string query = "SELECT * FROM Produto WHERE Id = @id";
                Produto produto= await conn.QueryFirstOrDefaultAsync<Produto>(sql: query, param: new { id });
                return produto;
            }
        }
        public async Task<List<Produto>> GetProdutoSearch(string campo)
        {
            using (var conn = _db.Connection)
            {
                string query = @"SELECT ID, Nome, Descricao, Preco, QtdeEstoque 
                         FROM Produto 
                         WHERE nome LIKE @campo COLLATE Latin1_General_CI_AI";
                var param = new { campo = $"%{campo}%" };
                List<Produto> produtos = (await conn.QueryAsync<Produto>(sql: query, param: param)).ToList();
                return produtos;
            }
        }
        public async Task<int> SaveAsync(Produto novoProduto)
        {
            using (var conn = _db.Connection)
            {
                string command = @"INSERT INTO Produto(Nome, Descricao,Preco,qtdeEstoque)
    		VALUES(@nome, @descricao, @preco, @qtdeEstoque)";
                var result = await conn.ExecuteAsync(sql: command, param: novoProduto);
                return result;
            }
        }
        public async Task<int> UpdateProdutoAsync(Produto atualizaProduto)
        {
            using (var conn = _db.Connection)
            {
                string command = @"
    		     UPDATE Produto SET nome = @nome, Descricao = @descricao, preco = @preco, qtdeEstoque = @qtdeEstoque WHERE Id = @Id";
                var result = await conn.ExecuteAsync(sql: command, param: atualizaProduto);
                return result;
            }
        }
        public async Task<int> DeleteAsync(int id)
        {
            using (var conn = _db.Connection)
            {
                string command = @"DELETE FROM Produto WHERE Id = @id";
                var resultado = await conn.ExecuteAsync(sql: command, param: new { id });
                return resultado;
            }
        }
    }
}
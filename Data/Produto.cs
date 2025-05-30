namespace DapperWebAPI.Data
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public decimal preco { get; set; }
        public int qtdeEstoque{ get; set; }
    }
}

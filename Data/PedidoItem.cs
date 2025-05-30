namespace DapperWebAPI.Data
{
    public class PedidoItem
    {
        public int id { get; set; }
        public Pedido pedido { get; set; }
        public Produto produto { get; set; }
        public decimal quantidade{ get; set; }
        public decimal precoUnitario{ get; set; }
    }
}

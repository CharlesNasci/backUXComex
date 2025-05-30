namespace DapperWebAPI.Data
{
    public class Pedido
    {
        public int id { get; set; }
        public Cliente cliente{ get; set; }
        public DateTime dataPedido{ get; set; }
        public decimal valorTotal{ get; set; }
        public string status{ get; set; }
    }
}

namespace Back_end_Challenge.Entities
{
    public class Order
    {

        public int pedido { get; set; }

        public required List<OrderItem> itens { get; set; }
    }

    public class OrderItem
    {
        public required string descricao { get; set; }
        public required decimal precoUnitario { get; set; }
        public required int qtd { get; set; }
    }

}

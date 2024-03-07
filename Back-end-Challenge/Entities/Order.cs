namespace Back_end_Challenge.Entities
{
    public class Order
    {

        public int Pedido { get; set; }

        public required List<OrderItem> Itens { get; set; }
    }

    public class OrderItem
    {
        public required string Descricao { get; set; }
        public required decimal PrecoUnitario { get; set; }
        public required int Qtd { get; set; }
    }

}

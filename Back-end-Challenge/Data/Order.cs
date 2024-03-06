namespace Back_end_Challenge.Data
{
    public class Order
    {
        public int OrderNumber { get; set; }

        public required List<OrderItem> Itens { get; set; }
    }


}

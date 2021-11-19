namespace TellDontAskKata.Main.UseCase
{
    public class OrderShipmentRequest
    {
        public int OrderId { get; private set; }

        public OrderShipmentRequest(int orderId)
        {
            OrderId = orderId;
        }
    }
}

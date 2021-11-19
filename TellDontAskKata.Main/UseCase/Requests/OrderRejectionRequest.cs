namespace TellDontAskKata.Main.UseCase
{
    public class OrderRejectionRequest
    {
        public int OrderId { get; private set; }

        public OrderRejectionRequest(int orderId)
        {
            OrderId = orderId;
        }
    }
}

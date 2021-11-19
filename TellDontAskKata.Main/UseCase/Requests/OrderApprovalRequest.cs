namespace TellDontAskKata.Main.UseCase
{
    public class OrderApprovalRequest
    {
        public int OrderId { get; private set; }

        public OrderApprovalRequest(int orderId)
        {
            OrderId = orderId;
        }
    }
}

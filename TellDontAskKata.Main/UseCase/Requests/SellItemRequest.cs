namespace TellDontAskKata.Main.UseCase
{
    public class SellItemRequest
    {
        public int Quantity { get; private set; }
        public string ProductName { get; private set; }

        public SellItemRequest(int quantity, string productName)
        {
            Quantity = quantity;
            ProductName = productName;
        }
    }
}

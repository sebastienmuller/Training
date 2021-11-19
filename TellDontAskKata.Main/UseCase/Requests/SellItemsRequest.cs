namespace TellDontAskKata.Main.UseCase
{
    public class SellItemsRequest
    {
        public IList<SellItemRequest> Requests { get; private set; }

        public SellItemsRequest(IList<SellItemRequest> requests)
        {
            Requests = requests;
        }
    }
}

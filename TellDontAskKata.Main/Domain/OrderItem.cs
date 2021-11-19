namespace TellDontAskKata.Main.Domain
{
    public class OrderItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal TaxedAmount { get; private set; }
        public decimal Tax { get; private set; }
    
        public OrderItem(Product product, int quantity, decimal taxedAmount, decimal tax)
        {
            Product = product;
            Quantity = quantity;
            TaxedAmount = taxedAmount;
            Tax = tax;
        }
    }
}

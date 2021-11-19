namespace TellDontAskKata.Main.Domain
{
    public class OrderItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal TaxedAmount { get; private set; }
        public decimal Tax { get; private set; }
    
        private OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            TaxedAmount = product.UnitaryTaxedAmount * quantity;
            Tax = product.UnitaryTax * quantity;
        }

        public static OrderItem Create(Product product, int quantity)
        {
            return new OrderItem(product, quantity);
        }
    }
}

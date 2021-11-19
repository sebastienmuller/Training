namespace TellDontAskKata.Main.Domain
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Category Category { get; private set; }
        
        private decimal UnitaryTaxedAmount { get; set; }
        private decimal UnitaryTax { get; set; }

        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;

            UnitaryTax = GetUnitaryTax();
            UnitaryTaxedAmount = GetUnitaryTaxedAmount();
        }

        public decimal GetTaxAmount(int quantity)
        {
            return Round(UnitaryTax * quantity);
        }

        public decimal GetTaxedAmount(int quantity)
        {
            return Round(UnitaryTaxedAmount * quantity);
        }

        private decimal GetUnitaryTaxedAmount()
        {
            return Round(Price + UnitaryTax);
        }

        private decimal GetUnitaryTax()
        {
            return Round((Price / 100m) * Category.TaxPercentage);
        }

        private static decimal Round(decimal amount)
        {
            return decimal.Round(amount, 2, MidpointRounding.ToPositiveInfinity);
        }
    }
}
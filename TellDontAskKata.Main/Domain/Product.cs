namespace TellDontAskKata.Main.Domain
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Category Category { get; private set; }
        
        public decimal UnitaryTaxedAmount { get; private set; }
        public decimal UnitaryTax { get; private set; }

        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;

            UnitaryTax = GetUnitaryTax();
            UnitaryTaxedAmount = GetUnitaryTaxedAmount();
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
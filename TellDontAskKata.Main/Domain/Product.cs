namespace TellDontAskKata.Main.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }

        public decimal GetTaxAmount(int quantity)
        {
            return Round(GetUnitaryTax() * quantity);
        }

        public decimal GetTaxedAmount(int quantity)
        {
            return Round(GetUnitaryTaxedAmount() * quantity);
        }

        private decimal GetUnitaryTaxedAmount()
        {
            return Round(Price + GetUnitaryTax());
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
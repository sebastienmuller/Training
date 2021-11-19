namespace TellDontAskKata.Main.Domain
{
    public class Category
    {
        public string Name { get; private set; }
        public decimal TaxPercentage { get; private set; }

        public Category(string name, decimal taxPercentage)
        {
            Name = name;
            TaxPercentage = taxPercentage;
        }
    }
}

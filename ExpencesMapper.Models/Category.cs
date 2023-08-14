namespace ExpensesMapper.Models
{
    public class Category
    {
        public string Name { get; }
        public decimal TotalAmount { get; private set; }

        public Category(string categoryName, decimal amount)
        {
            Name = categoryName;
            TotalAmount = amount;
        }

        public void AddAmount(decimal amount)
        {
            TotalAmount += amount;
        }
    }
}